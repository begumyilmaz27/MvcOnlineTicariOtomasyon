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
        public ActionResult Index()
        {
            var products = c.Products.Where(x=>x.ProductSituation==true).ToList();
            return View(products);
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
    }
}