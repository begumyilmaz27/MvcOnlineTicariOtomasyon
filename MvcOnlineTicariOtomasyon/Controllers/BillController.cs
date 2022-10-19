using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Bills.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult BillAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BillAdd(Bills k)
        {
            c.Bills.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}