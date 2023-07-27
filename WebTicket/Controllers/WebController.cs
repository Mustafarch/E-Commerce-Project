using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebTicket.Business;
using WebTicket.DAL;
using WebTicket.Entities;
using WebTicket.Models.DTO;
using X.PagedList;

namespace WebTicket.Controllers
{
    public class WebController : Controller

    {
        public WebContext db;
        public WebController()
        {
            db = new WebContext();
        }

        BaseController bc = new BaseController();

        //[Route("Anasayfa")]
        public IActionResult Index()
        {

            Setting();
            return View();
        }

        public void Setting()
        {
            var ayarbul = db.Settings.FirstOrDefault();


            if (ayarbul != null)
            {
                ViewBag.Explanation = ayarbul.Explanation;
                ViewBag.SiteName = ayarbul.SiteName;
                ViewBag.Phone = ayarbul.Phone;
                ViewBag.Mail = ayarbul.Mail;
                ViewBag.Adress = ayarbul.Adress;
                ViewBag.About = ayarbul.About;/*.Substring(0, 100)*/


            }
            else
            {
                RedirectToAction("Index", "Web");
            }

            ViewBag.SliderList = db.Sliders.ToList();
            ViewBag.Setting = db.Settings.ToList();
            ViewBag.Blogs = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            ViewBag.Product = db.Products.OrderBy(x => x.ID).ToList();
            ViewBag.ProductC = db.Products.OrderBy(x => x.ID).Take(1).ToList();
            ViewBag.Product3 = db.Products.OrderBy(x => x.ID).Take(3).ToList();
            ViewBag.Category = db.Categories.OrderBy(x => x.ID).Take(3).ToList();
            ViewBag.CartList = db.Carts.ToList();
            ViewBag.Rew = db.BlogReviews.ToList();
            ViewBag.Satilan = db.Satilanlar.ToList();
            
            


        }


        [Route("blog-detay/{id}")]
        public IActionResult BlogDetail(int id)
        {
            Setting();
            var bul = bc.Blog_Find(id);
            ViewBag.Review = db.BlogReviews.Where(x => x.BlogID == bul.ID).ToList();
            bul.ReadNumber++;
            bc.db.SaveChanges();
            return View(bul);
        }
        [Route("blog-listele")]
        public IActionResult Blog()
        {
            Setting();
            
            return View(bc.Blog_List());
        }
        [Route("blog-listele")]
        [HttpPost]
        public IActionResult Blog(string ara)
        {
            Setting();
            var kontrol2 = db.Blogs.ToList();
            var kontrol = db.Blogs.Where(x => x.Title.Contains(ara) || x.Author.Contains(ara) || x.Contents.Contains(ara)).ToList();
            
            if (kontrol.Count > 0)
            {
                return View(kontrol);
            }
            else
            {
                ViewBag.Durum = "Aradığınız içerik bulunamadı.";
                return View(kontrol);
            }
           
        }

        [Route("yorumu-ekle")]

        [HttpPost]
        public IActionResult ReviewAdd(int BlogID, string NameSurname, string Review, string Mail, string Picture )
        {
            var yeni = new BlogReview {BlogID=BlogID, NameSurname = NameSurname, Review = Review, Mail = Mail, Picture=Picture, Date=DateTime.Now };
            db.BlogReviews.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("BlogDetail","Web", new {id=BlogID});
        }
        [Route("yorum-ekle")]
        [HttpPost]
        public IActionResult ReviewProductAdd(int ProductID, string NameSurname, string Review, string Mail, string Picture)
        {
            var yeni = new ProductReview { ProductID = ProductID, NameSurname = NameSurname, Review = Review, Mail = Mail, Picture = Picture, Date = DateTime.Now };
            db.ProductReviews.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("ProductDet", "Web", new { id = ProductID });
        }
        [Route("hakkimizda-goster")]
        public IActionResult About()
        {
            Setting();

            return View(ViewBag.Setting);
        }
        [Route("iletisimi-ekle")]
        public IActionResult ContactAdd()
        {
            Setting();
            return View();
        }
        [Route("iletisimi-ekle")]
        [HttpPost]
        public IActionResult ContactAdd(Contact model)
        {
            bool kontrol = bc.Contact_Add(model);
            if (kontrol == true)
            {
                Setting();
                ViewBag.Durum = "İsteğiniz başarılı bir şekilde alındı.";
                
                return View();
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }
        [Route("urun-detay/{id}")]
        public IActionResult ProductDet(int id)
        {
            Setting();
            var bul = bc.Product_Find(id);
            ViewBag.ProductReview = db.ProductReviews.Where(x => x.ProductID == bul.ID).ToList();
            bc.db.SaveChanges();

            return View(bul);

        }




        [Route("kategori-filtre/{kategori}")]
        public IActionResult CategoryFiltre(int kategori)
        {
            Setting();
            var bul = bc.db.Products.Where(x => x.CategoryID == kategori).ToList();

            return View(bul);
        }

        [Route("sepet-listesi")]
        public IActionResult SepetList(/*int id*/)
        {
            Setting();
            return View(db.Carts.ToList());
        }
        [Route("sepet-ekle/{id}")]
        public IActionResult CartAdd(int id)
        {
            var find = bc.db.Products.FirstOrDefault(x => x.ID == id);
            Cart crt = new Cart();
            var  kntrl = db.Carts.FirstOrDefault(x => x.ProductID == id);
           
            if (kntrl != null)
            {
                var cartfind = db.Carts.FirstOrDefault(x => x.ProductID == id);
                cartfind.ProductQuantity += 1;
                cartfind.ProductPrice = find.ProductPrice;
                cartfind.ProductTotal = cartfind.ProductQuantity * find.ProductPrice;
                cartfind.ProductPicture = find.ProductPicture;
                
                cartfind.ProductName = find.ProductName;
                
               
                db.SaveChanges();

                return RedirectToAction("SepetList", "Web");

            }
            else
            {
                crt.ProductID = find.ID;
                crt.ProductQuantity = 1;
                crt.ProductPrice = find.ProductPrice;
                crt.ProductTotal = crt.ProductQuantity * find.ProductPrice;
                crt.ProductPicture = find.ProductPicture;
                crt.ProductName = find.ProductName;
                
               
                db.Carts.Add(crt);
                db.SaveChanges();
                return RedirectToAction("SepetList", "Web");
            }
           
            
        }
        [Route("urun-sil/{id}")]
        public IActionResult CartDelete(int id)
        {

            var kontrol = bc.Cart_Delete(id);
            if (kontrol == true)
            {
                return RedirectToAction("SepetList", "Web");
            }
            else
            {
                TempData["Durum"] = "Ürün Silinemedi!";
                return RedirectToAction("SepetList", "Web");
            }
       }
        [Route("urun-liste")]
        public IActionResult ProductL()
        {

            Setting();
            return View(bc.Product_List());
        }
        [Route("urun-liste")]
        [HttpPost]
        public IActionResult ProductL(string ara)
        {
            Setting();
            var kontrol2 = db.Products.ToList();
            var kontrol = db.Products.Where(x => x.ProductName.Contains(ara) || x.ProductExplanation.Contains(ara)).ToList();
            if (kontrol.Count > 0)
            {
                return View(kontrol);
            }
            else
            {
                ViewBag.Durum = "Aradığınız içerik bulunamadı.";
                return View(kontrol);
            }
        }

        [Route("alisveris-bitir")]
        public IActionResult CheckOutEnd()
        {
            Setting();
            var liste = db.Carts.ToList();
            return View(liste);

        }
        [Route("alisveris-bitir")]
        [HttpPost]
        public IActionResult CheckOutEnd(string Name, string Surname, string Adres, string Mail, string Phone)

        {
            try
            {
                var siparis = new Siparis()
                {
                    Name = Name,
                    Surname = Surname,
                    Adres = Adres,
                    Mail = Mail,
                    Phone = Phone,

                };
                db.Siparisler.Add(siparis);
                db.SaveChanges();

                var bul = db.Carts.ToList();
                foreach (var item in bul)
                {
                    var satis = new Satilanlar()
                    {
                        ProductName = item.ProductName,
                        ProductQuantity = item.ProductQuantity,
                        ProductTotal = item.ProductTotal,
                        ProductID = item.ID,
                        SiparisID = siparis.ID,
                    };
                    db.Satilanlar.Add(satis);
                    db.SaveChanges();
                }
                db.Carts.RemoveRange(bul);
                db.SaveChanges();
                return RedirectToAction("Onay","Web");
            }
            catch (Exception)
            {

                return RedirectToAction("Index","Web");
            }
        }
        [Route("onay")]
        public IActionResult Onay()
        {
            Setting();
            return View();
        }
        [Route("siparis-listesi")]
        public IActionResult SiparisListesi(int page = 1)
        {
            Setting();
            return View(db.Siparisler.ToList().ToPagedList(page, 10));
        }
        [Route("satilan-listesi/{id}")]
        public IActionResult SatilanListesi(int id)
        {
            Setting();
            var bul = db.Satilanlar.Where(x => x.SiparisID == id);
            return View(bul.ToList());
        }
        [Route("siparis-sil/{id}")]
        public IActionResult SiparisSil(int id)
        {
            Setting();
            bool silindimi = bc.Siparis_Sil(id);
            if (silindimi == true)
            {
                TempData["Durum"] = "Sipariş Silindi";
                return RedirectToAction("SiparisListesi");
            }
            else
            {
                TempData["Durum"] = "Hata Sipariş Silinemedi!";
                return RedirectToAction("SiparisListesi");
            }
        }
        [Route("ara")]
        public IActionResult Search()
        {
            Setting();
            return View();
        }

        [Route("ara")]
        [HttpPost]
        public IActionResult Search(string search)
        {
            Setting();
            ViewBag.BlogSearch = db.Blogs.Where(x => x.Title.Contains(search) || x.Contents.Contains(search)).ToList();
            ViewBag.ProductSearch = db.Products.Where(x => x.ProductName.Contains(search) || x.ProductExplanation.Contains(search)).ToList();
            if (ViewBag.BlogSearch.Count > 0 || ViewBag.ProductSearch.Count > 0)
            {
                return View();
            }
            else
            {
                ViewBag.Durum = "Böyle Bir İçerik Bulunamadı";
                return View();
            }
        }
        [Route("azalt/{id}")]
        public IActionResult Decrease(int id)
        {
            var model = db.Carts.Find(id);
            if (model.ProductQuantity==1)
            {
                db.Carts.Remove(model);
                db.SaveChanges();
            }
            model.ProductQuantity--;
            model.ProductTotal=model.ProductPrice * model.ProductQuantity;
            db.SaveChanges();
            return RedirectToAction("SepetList", "Web");
        }
        [Route("arttir/{id}")]
        public IActionResult Increase(int id)
        {
            var model =db.Carts.Find(id);
            model.ProductQuantity++;
            model.ProductTotal = model.ProductPrice * model.ProductQuantity;
            db.SaveChanges();
            return RedirectToAction("SepetList", "Web");

        }

    }
}
