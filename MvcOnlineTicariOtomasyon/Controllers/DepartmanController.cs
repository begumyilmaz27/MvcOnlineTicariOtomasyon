using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x => x.DepartmanSituation == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanAdd(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDelete(int id)
        {
            var deger = c.Departmen.Find(id);
            deger.DepartmanSituation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanBring(int id)
        {
            var departmandeger = c.Departmen.Find(id);
            return View("DepartmanBring", departmandeger);
        }
        public ActionResult DepartmanUpdate(Departman d1)
        {
            var dept = c.Departmen.Find(d1.DepartmanId);
            dept.DepartmanName = d1.DepartmanName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetail(int id)
        {
            return View();
        }

    }
}