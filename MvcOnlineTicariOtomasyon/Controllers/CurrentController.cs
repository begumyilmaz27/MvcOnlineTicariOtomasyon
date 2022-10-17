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
            var degerler = c.Currents.Where(x=>x.CurrentSituation==true).ToList();
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
            p.CurrentSituation = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var cr = c.Currents.Find(id);
            cr.CurrentSituation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentBring (int id)
        {
            var cari = c.Currents.Find(id);
            return View("CurrentBring", cari);
        }
        public ActionResult CurrentUpdate(Current p)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentBring");
            }
            var cari=c.Currents.Find(p.CurrentID);
            cari.CurrentName = p.CurrentName;
            cari.CurrentSurname = p.CurrentSurname;
            cari.CurrentMail = p.CurrentMail;
            cari.CurrentCity = p.CurrentCity;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSales(int id)
        {
            var degerler = c.SalesMovements.Where(x => x.CurrentID == id).ToList();
            var cr=c.Currents.Where(x => x.CurrentID == id).ToList().Select(y => y.CurrentName+" " + y.CurrentSurname).FirstOrDefault();
            ViewBag.current = cr;
            return View(degerler);
        }


    }
}