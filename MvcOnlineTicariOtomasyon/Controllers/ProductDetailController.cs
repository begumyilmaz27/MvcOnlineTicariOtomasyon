using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.Deger1 = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.Deger2 = c.Details.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}