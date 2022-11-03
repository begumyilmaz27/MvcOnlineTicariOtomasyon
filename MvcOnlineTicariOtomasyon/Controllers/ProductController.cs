using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string p)  //Index içine yazdığımız Product Name:@Html.TextBox("p") kodundaki parantez içindeki p değişkenini burada tanımladık.
        {
            var urunler = from x in c.Products select x; //x'i ürünler içinden alacaksın ve x'i seçeceksin
            if (!string.IsNullOrEmpty(p))     //eğer göndermiş olduğum parametre boş değilse ya da null değilse aşağıdakini yapacaskın
            {
                urunler = urunler.Where(y => y.ProductName.Contains(p));  //Urun adında P'de yazdığımız değişkeni içeriden değeri urunler yazdığımız değişkenin içine atayacak.
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var deger = c.Products.Find(id);
            deger.ProductSituation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var productdeger = c.Products.Find(id);
            return View("ProductBring", productdeger);
        }
        public ActionResult ProductUpdate (Product p)
        {
            var urn = c.Products.Find(p.ProductID);
            urn.ProductPurchasePrice=p.ProductPurchasePrice;
            urn.ProductSituation=p.ProductSituation;
            urn.CategoryId = p.CategoryId;
            urn.ProductBrand = p.ProductBrand;
            urn.ProductSalePrice = p.ProductSalePrice;
            urn.ProductStock = p.ProductStock;
            urn.ProductName=p.ProductName;
            urn.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }

        //Tıpki yeni bir şey ekleme işleminde olduğu gibi bir yapı kullanıyoru aşağıdaki SatışYapda. 

        [HttpGet]
        public ActionResult MakeaSale(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;

            var deger1 = c.Products.Find(id); //deger1 ile ürün tablosundan gelen ID'yi bulduk
            ViewBag.dgr1 = deger1.ProductID;  //ViewBag ile gelen Id'yi aldık

            ViewBag.dgr2 = deger1.ProductSalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult MakeaSale(SalesMovement p)
        {
            p.SalesMovement_Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(p);
            c.SaveChanges();           

            return RedirectToAction("Index", "SalesMovement");
        }
    }
}