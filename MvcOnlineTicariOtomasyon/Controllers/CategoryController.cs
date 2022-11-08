using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c=new Context();   //Contextten ürettiğimiz C nesnesi 
        public ActionResult Index(int page=1) //Paged paketi ekledikten sonra projeye listeleme işlemini Index'de gerçekleştireceğiz için page isminde değişken oluşturduk. 1 dedik; kaç dersek listekeme işlemi oradan başlar.
        {
            var degerler = c.Categories.ToList().ToPagedList(page,5); 
                //ToPagedLİst iki tane parametre alıyor başlangıç parametresi ve size. Size kısmı genelde 10 yada 12 olacak şekilde kullanılır.
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        { 
            return View();         
        }
        
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult CategoryDelete(int id)
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var ctgB = c.Categories.Find(id);
            return View("CategoryBring",ctgB);
        }
        public ActionResult CategoryUpdate(Category k)
        {
            var ctgU = c.Categories.Find(k.CategoryID);
            ctgU.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            class4 cs = new class4(); //Class4'den cs isminde bir nesne türettik. 

            cs.Kategoriler = new SelectList(c.Categories, "CategoryID", "CategoryName"); //Category sınıfından ya da Categories tablosundan CategoryID ve CategoryNAme'i aldık. 

            cs.Urunler = new SelectList(c.Products, "ProductID", "ProductName");

            return View(cs);
        }
        public JsonResult BringProduct(int p) //urun getirin bir parametre alması gerekiyor (int p ) yazdık bu yüzden. bu parametre yukarıda oluşturduğumuz Deneme.cshtml'de oluşturduğumuz FropDownList şeyi. Kullanıcı Browserdan seçeceği değer buranın parametresi olacak
        {
            var urunlistesi = (from x in c.Products
                               join y in c.Categories //Birleştirme işlemi kullanıyor
                               on x.Category.CategoryID equals y.CategoryID //şartım birleştirmedeki burada yazan
                               where x.Category.CategoryID == p //bütün değerleri bana döndürme diyoruz burada. şartımız şu ürünler tablosunda bir CategoryID değerini çekeceğiz ama bu ID p'ye eşit olan olacak
                               select new 
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductID.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet); 
        }


    }
}