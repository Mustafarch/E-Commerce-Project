using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebTicket.DAL;
using WebTicket.Entities;



namespace WebTicket.Business
{
    public class BaseController
    {
        public WebContext db;
        public BaseController()
        {
            db = new WebContext();
        }


        //public void Setting()
        //{
        //    var ayarbul = db.Settings.FirstOrDefault();


        //    if (ayarbul != null)
        //    {
        //        //ViewBag.Explanation = ayarbul.Explanation;
        //        //ViewBag.SiteName = ayarbul.SiteName;
        //        //ViewBag.Phone = ayarbul.Phone;
        //        //ViewBag.Mail = ayarbul.Mail;
        //        //ViewBag.Adress = ayarbul.Adress;
        //        //ViewBag.About = ayarbul.About;/*.Substring(0, 100)*/


        //    }
        //    else
        //    {
        //        //RedirectToAction("Index", "Web");
        //    }

        //    //ViewBag.SliderList = db.Sliders.ToList();
        //    //ViewBag.Setting = db.Settings.ToList();
        //    //ViewBag.Blogs = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
        //    //ViewBag.Product = db.Products.OrderBy(x => x.ID).ToList();
        //    //ViewBag.ProductC = db.Products.OrderBy(x => x.ID).Take(1).ToList();
        //    //ViewBag.Product3 = db.Products.OrderBy(x => x.ID).Take(3).ToList();
        //    //ViewBag.Category = db.Categories.OrderBy(x => x.ID).Take(3).ToList();


        //}

        public List<Slider> Slider_List()
        {
            return db.Sliders.ToList();
        }
        public bool Slider_Add(Slider model)
        {
            try
            {
                db.Sliders.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Slider Slider_Find(int id)
        {
            return db.Sliders.FirstOrDefault(x => x.ID == id);
        }

        public bool Slider_Edit(Slider model)
        {
            try
            {
                var bul = Slider_Find(model.ID);
                if (model.Contents != null)
                {
                    bul.Contents = model.Contents;
                }

                if (model.Title != null)
                {
                    bul.Title = model.Title;
                }

                if (model.Picture != null)
                {
                    bul.Picture = model.Picture;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Slider_Delete(int id)
        {
            try
            {
                var bul = Slider_Find(id);
                db.Sliders.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Blog Blog_Find(int id)
        {
            return db.Blogs.FirstOrDefault(x => x.ID == id);
        }
        public List<Blog> Blog_List()
        {
            return db.Blogs.ToList();
        }
        public bool Blog_Add(Blog model)
        {
            try
            {
                model.History = DateTime.Now;
                db.Blogs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Blog_Edit(Blog model)
        {
            try
            {

                var bul = Blog_Find(model.ID);
                if (model.Author != null)
                {
                    bul.Author = model.Author;
                }

                if (model.Title != null)
                {
                    bul.Title = model.Title;
                }

                if (model.Contents != null)
                {
                    bul.Contents = model.Contents;
                }

                db.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Blog_Delete(int id)
        {
            try
            {
                var bul = Blog_Find(id);
                db.Blogs.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /////////PRODUCT BASECONTROLLER

        public List<ProductDTO> Product_Listt()
        {
            List<ProductDTO> urun = new List<ProductDTO>();
            var listebul = db.Products.ToList();


            foreach (var item in listebul)
            {
                var sinifbul = db.Categories.FirstOrDefault(x => x.ID == item.CategoryID);
                ProductDTO yeni = new ProductDTO { ID = item.ID, ProductName = item.ProductName, ProductPrice = item.ProductPrice, ProductPicture = item.ProductPicture, ProductSize = item.ProductSize, ProductColor = item.ProductColor, ProductStok = item.ProductStok, ProductQuantity = item.ProductQuantity, ProductTotal = item.ProductTotal, ProductExplanation = item.ProductExplanation, CategoryName = sinifbul.CategoryName };
                urun.Add(yeni);
            }
            return urun;

        }

        public List<Product> Product_List()
        {
            return db.Products.ToList();
        }

        public Product Product_Find(int id)
        {
            return db.Products.FirstOrDefault(X => X.ID == id);
        }
        public bool Product_Add(Product veri)
        {
            try
            {
                db.Products.Add(veri);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Product_Delete(int id)
        {
            //var silindimi = Ogrenci_Bul(id);
            try
            {
                db.Products.Remove(Product_Find(id));
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Product_Edit(Product model)
        {

            try
            {
                var bul = Product_Find(model.ID);
                if (model.ProductName != null)
                {
                    bul.ProductName = model.ProductName;
                }

                if (model.ProductPrice != null)
                {
                    bul.ProductPrice = model.ProductPrice;
                }

                if (model.ProductPicture != null)
                {
                    bul.ProductPicture = model.ProductPicture;
                }
                if (model.ProductSize != null)
                {
                    bul.ProductSize = model.ProductSize;
                }
                if (model.ProductColor != null)
                {
                    bul.ProductColor = model.ProductColor;
                }
                if (model.ProductStok != null)
                {
                    bul.ProductStok = model.ProductStok;
                }
                if (model.ProductExplanation != null)
                {
                    bul.ProductExplanation = model.ProductExplanation;
                }
                if (model.CategoryID != null)
                {
                    bul.CategoryID = model.CategoryID;
                }
                db.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;

            }
        }

        ///////// Category BaseController

        public List<Category> Category_List()
        {
            return db.Categories.ToList();
        }
        public bool Category_Add(Category model)
        {
            try
            {
                //Setting();
                db.Categories.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Category Category_Find(int id)
        {
            return db.Categories.FirstOrDefault(x => x.ID == id);
        }

        public bool Category_Edit(Category model)
        {

            try
            {
                var bul = Category_Find(model.ID);
                if (model.CategoryName != null)
                {
                    bul.CategoryName = model.CategoryName;
                }

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Category_Delete(int id)
        {
            try
            {
                var bul = Category_Find(id);
                db.Categories.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Contact> Contact_List()
        {
            //Setting();
            return db.Contacts.ToList();
        }
        public bool Contact_Add(Contact model)
        {
            try
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Contact Contact_Find(int id)
        {
            return db.Contacts.FirstOrDefault(x => x.ID == id);
        }

        public bool Contact_Delete(int id)
        {
            try
            {
                var bul = Contact_Find(id);
                db.Contacts.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Setting_Edit(Setting model)
        {

            try
            {
                var bul = Setting_Find(model.ID);
                if (model.SiteName != null)
                {
                    bul.SiteName = model.SiteName;
                }

                if (model.Explanation != null)
                {
                    bul.Explanation = model.Explanation;
                }

                if (model.Adress != null)
                {
                    bul.Adress = model.Adress;
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

                db.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Setting> Setting_List()
        {
            return db.Settings.ToList();
        }

        public Setting Setting_Find(int id)
        {
            return db.Settings.FirstOrDefault(x => x.ID == id);
        }

        public bool Setting_Add(Setting model)
        {
            try
            {
                db.Settings.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sepet_Add(Product model)
        {

            try
            {

                //Setting();
                db.Products.Add(model);

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public List<Product> Sepet_List()
        //{
        //    return db.Products.ToList();
        //}

        public Cart Cart_Find(int id)
        {
            return db.Carts.FirstOrDefault(x => x.ID == id);
        }


        public bool Cart_Delete(int id)
        {
            try
            {
                var bul = Cart_Find(id);
                db.Carts.Remove(bul);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Siparis_Sil(int id)
        {
            try
            {
                var bul = db.Siparisler.FirstOrDefault(x => x.ID == id);
                db.Siparisler.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Satilanlar> Satilan_Listesi()
        {
            return db.Satilanlar.ToList();
        }
    }
}
