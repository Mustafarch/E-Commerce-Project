using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTicket.Business;
using WebTicket.DAL;
using WebTicket.Entities;


using X.PagedList;

namespace WebTicket.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public WebContext db;
        public AdminController()
        {
            db = new WebContext();
        }
        BaseController bc = new BaseController();

        
        public IActionResult Index()
        {
            return View();
        }
        [Route("anasayfa")]
        public IActionResult Web()
        {
            return RedirectToAction("Index", "Web");
        }
        [Route("slider")]
        public IActionResult SliderList(int page = 1)
        {
            return View(bc.Slider_List().ToPagedList(page, 4));
        }
        [Route("slider-ekle")]
        public IActionResult SliderAdd()
        {
            return View();
        }
        [Route("slider-ekle")]
        [HttpPost]
        public IActionResult SliderAdd(Slider model)
        {
            bool kontrol = bc.Slider_Add(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderList");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }
        [Route("slider-duzenle/{id}")]
        public IActionResult SliderEdit(int id)
        {
            return View(bc.Slider_Find(id));
        }
        [Route("slider-duzenle/{id}")]
        [HttpPost]
        public IActionResult SliderEdit(Slider model)
        {
            var kontrol = bc.Slider_Edit(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderList");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }
        [Route("slider-sil/{id}")]
        public IActionResult SliderDelete(int id)
        {
            var kontrol = bc.Slider_Delete(id);
            if (kontrol == true)
            {
                TempData["Durum"] = "Slider başarılı bir şekilde silindi.";
                return RedirectToAction("SliderList");
            }
            else
            {
                TempData["Durum"] = "Slider Silinemedi!";
                return RedirectToAction("SliderListesi");
            }
        }

        [Route("blog-liste")]
        public IActionResult Blog(int page = 1)
        {
            return View(bc.Blog_List().ToPagedList(page, 4));
        }
        [Route("blog-ekle")]
        public IActionResult BlogAdd()
        {
            return View();
        }

        [Route("blog-ekle")]
        [HttpPost]
        public IActionResult BlogAdd(Blog model)
        {
            var kontrol = bc.Blog_Add(model);
            if (kontrol == true)
            {
                return RedirectToAction("Blog","Admin");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("blog-duzenle/{id}")]
        public IActionResult BlogEdit(int id)
        {
            return View(bc.Blog_Find(id));
        }
        [Route("blog-duzenle/{id}")]
        [HttpPost]
        public IActionResult BlogEdit(Blog model)
        {
            var kontrol = bc.Blog_Edit(model);
            if (kontrol == true)
            {
                return RedirectToAction("Blog");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("blog-sil/{id}")]
        public IActionResult BlogDelete(int id)
        {
            var kontrol = bc.Blog_Delete(id);
            if (kontrol == true)
            {
                TempData["Durum"] = "Blog başarılı bir şekilde Silindi";
                return RedirectToAction("Blog");
            }
            else
            {
                TempData["Durum"] = "Veritabansal bir hata oluştu";
                return RedirectToAction("Blog");
            }
        }

        [Route("hakkinda-duzenle/{id}")]
        public IActionResult AboutEdit()
        {
            return View(bc.db.Settings.FirstOrDefault());
        }

        [Route("hakkinda-duzenle/{id}")]
        [HttpPost]
        public IActionResult AboutEdit(Setting model)
        {
            try
            {
                var bul = bc.db.Settings.FirstOrDefault();
                bul.About = model.About;
                bc.db.SaveChanges();
                ViewBag.Durum = "1";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Durum = "2";
                return View();
            }
        }

        /////////////PRODUCT ADMİNCONTROLLER
        [Route("urun-listesi")]
        public IActionResult ProductList(int page = 1)
        {
            
            return View(bc.Product_Listt().ToPagedList(page, 4));
        }
        [Route("urun-ekle")]
        public IActionResult ProductAdd()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            return View();
        }

        [Route("urun-ekle")]
        [HttpPost]
        public IActionResult ProductAdd(Product veri)
        {
            bool eklendimi = bc.Product_Add(veri);
            if (eklendimi == true)
            {
                ViewBag.Durum = "Ürün Başarıyla eklendi.";
                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu.";
                return View();
            }
        }
        [Route("urunu-sil/{id}")]
        public IActionResult ProductDelete(int id)
        {
            bool silindimi = bc.Product_Delete(id);
            if (silindimi == true)
            {
                TempData["Durum"] = "Ürün başarılı şekilde silindi";
                return RedirectToAction("ProductList");
            }
            else
            {
                TempData["Durum"] = "Hata Ürün Silinemedi!";
                return RedirectToAction("ProductList");
            }
        }
        [Route("urunu-duzenle/{id}")]
        public IActionResult ProductEdit(int id)
        {
            return View(bc.Product_Find(id));
        }

        [Route("urunu-duzenle/{id}")]
        [HttpPost]
        public IActionResult ProductEdit(Product model)
        {

            bool eklendimi = bc.Product_Edit(model);
            if (eklendimi == true)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu.";
                return View();
            }
        }
        [Route("urunler")]
        public IActionResult ProductL()
        {
            return View(bc.Product_List());
        }

        /////////  CATEGORY ADMİNCONTROLLER
        [Route("kategori-listele")]
        public IActionResult CategoryList(int page = 1)
        {
            return View(bc.Category_List().ToPagedList(page, 4));
        }
        [Route("kategori-ekle")]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [Route("kategori-ekle")]
        [HttpPost]
        public IActionResult CategoryAdd(Category veri)
        {
            bool eklendimi = bc.Category_Add(veri);
            if (eklendimi == true)
            {
                ViewBag.Durum = "Kategori Başarıyla eklendi.";
                return RedirectToAction("CategoryList", "Admin");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu.";
                return View();
            }
        }
        [Route("kategori-sil/{id}")]
        public IActionResult CategoryDelete(int id)
        {
            bool silindimi = bc.Category_Delete(id);
            if (silindimi == true)
            {
                TempData["Durum"] = "Kategori Silindi";
                return RedirectToAction("CategoryList");
            }
            else
            {
                TempData["Durum"] = "Hata Kategori Silinemedi!";
                return RedirectToAction("CategoryList");
            }
        }
        [Route("kategori-duzenle/{id}")]
        public IActionResult CategoryEdit(int id)
        {
            return View(bc.Category_Find(id));
        }

        [Route("kategori-duzenle/{id}")]
        [HttpPost]
        public IActionResult CategoryEdit(Category veri)
        {

            bool eklendimi = bc.Category_Edit(veri);
            if (eklendimi == true)
            {
                return RedirectToAction("CategoryList");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu.";
                return View();
            }
        }
        [Route("hakkında-duzenle/{id}")]
        public IActionResult AboutEditt()
        {
            
            return View(ViewBag.About);
        }

        [Route("hakkında-duzenle/{id}")]
        [HttpPost]
        public IActionResult AboutEditt(Setting model)
        {
           
            try
            {
                var bul = bc.db.Settings.FirstOrDefault();
                if (model.About != null)
                {
                    bul.About = model.About;
                }

                if (model.Adress != null)
                {
                    bul.Adress = model.Adress;
                }


                bc.db.SaveChanges();
                ViewBag.Durum = "1";
                return View(ViewBag.About);
            }
            catch (Exception)
            {
                ViewBag.Durum = "2";
                return View(ViewBag.About);
            }
        }

        /// /////////////////////////////////

        [Route("iletisim-listesi")]
        public IActionResult ContactList(int page = 1)
        {
            //bc.Setting();
            return View(bc.Contact_List().ToPagedList(page, 4));
        }

        [Route("iletisim-sil/{id}")]
        public IActionResult ContactDelete(int id)
        {
            bool silindimi = bc.Contact_Delete(id);
            if (silindimi == true)
            {
                TempData["Durum"] = "Yorum Silindi";
                return RedirectToAction("ContactList");
            }
            else
            {
                TempData["Durum"] = "Hata Yorum Silinemedi!";
                return RedirectToAction("ContactList");
            }
        }

        ///////////////////////////Setting
        ///
        [Route("ayar-duzenle/{id}")]
        public IActionResult SettingEditt()
        {

            return View(ViewBag.Setting);
        }

        [Route("ayar-duzenle/{id}")]
        [HttpPost]
        public IActionResult SettingEditt(Setting model)
        {

            try
            {

                var bul = bc.db.Settings.FirstOrDefault();
                if (model.Adress != null)
                {
                    bul.Adress = model.Adress;
                }

                if (model.Explanation != null)
                {
                    bul.Explanation = model.Explanation;
                }

                if (model.SiteName != null)
                {
                    bul.SiteName = model.SiteName;
                }
                if (model.Phone != null)
                {
                    bul.Phone = model.Phone;
                }

                if (model.Mail != null)
                {
                    bul.Mail = model.Mail;
                }
                if (model.About != null)
                {
                    bul.About = model.About;
                }


                bc.db.SaveChanges();
                ViewBag.Durum = "1";
                return View(ViewBag.Setting);

           
            }
            catch (Exception)
            {
                ViewBag.Durum = "2";
                return View(ViewBag.Setting);
            }
        }
        [Route("ayar-listele")]
        public IActionResult SettingList()
        {
            return View(bc.Setting_List());
        }
        [Route("ayar-ekle")]
        public IActionResult SettingAdd()
        {
            return View();
        }

        [Route("ayar-ekle")]
        [HttpPost]
        public IActionResult SettingAdd(Setting veri)
        {
            bool eklendimi = bc.Setting_Add(veri);
            if (eklendimi == true)
            {
                ViewBag.Durum = "Ayar Başarıyla eklendi. 'Ayarlar Listele' bölümünde düzenleyebilirsiniz.";
                return View();
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu.";
                return View();
            }
        }

        [Route("ayar-detay/{id}")]
        public IActionResult ContactDetail(int id)
        {
            var bul = bc.db.Contacts.FirstOrDefault(x => x.ID == id);
            return View(bul);
        }

       

    }
}
