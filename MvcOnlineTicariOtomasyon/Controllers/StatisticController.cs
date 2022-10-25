using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Employees.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Products.Sum(x => x.ProductStock).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            //Distinct tekrar eden kodların 1 sefer dönmesini sağlar. 
            ViewBag.d6 = deger6;

            var deger7 = c.Products.Count(x => x.ProductStock <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Products orderby x.ProductPurchasePrice descending select x.ProductName).FirstOrDefault();
            //FirstOrDefault() listedeki ilk değeri getirecek
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Products orderby x.ProductSalePrice ascending select x.ProductName).FirstOrDefault();
            //ascending a'dan z'ye sıralama ya da en küçükten en büyüğe
            ViewBag.d9 = deger9;

            var deger10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = c.Products.Where(u => u.ProductID == (c.SalesMovements.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SalesMovements.Sum(x => x.SalesMovement_TotalAmount).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SalesMovements.Count(x => x.SalesMovement_Date == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SalesMovements.Where(x => x.SalesMovement_Date == bugun).Sum(y => (decimal?)y.SalesMovement_TotalAmount).ToString();
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult SimpleTables()
        {
            //ClassGroup da yazdığımız 2 property için Action oluşturuyoruz burada

            var sorgu = from x in c.Currents  //cariler içinde seç dedik
                        group x by x.CurrentCity into g //City'ye göre gruplandır ve g diye oluşturduğumuz soyut değer içine gönder dedik
                        select new ClassGroup //Burası önemli; anonymous type kullandığımız için sınıf adını yazmak zorundayız
                        {
                            City = g.Key,   //
                            Number = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Employees
                         group x by x.Departman.DepartmanId into g
                         select new Class2
                         {
                             Departman = g.Key,
                             Number = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Currents.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Products
                        group x by x.ProductBrand into g
                        select new Class3
                        {
                            brand = g.Key,
                            number = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }



    }
}