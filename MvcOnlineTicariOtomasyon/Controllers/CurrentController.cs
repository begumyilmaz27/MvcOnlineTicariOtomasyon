using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Currents.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrent(Current p)
        {
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}