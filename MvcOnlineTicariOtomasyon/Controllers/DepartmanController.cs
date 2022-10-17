using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            d.DepartmanSituation=true;
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
            var degerler=c.Employees.Where(e => e.EmployeeID == id).ToList();
            var dpt=c.Departmen.Where(x=>x.DepartmanId==id).Select(y=>y.DepartmanName).FirstOrDefault();
            ViewBag.d=dpt;
            return View(degerler);
        }
        public ActionResult DepartmanEmployeeSalesment(int id)
        {
            var degerler1=c.SalesMovements.Where(x=>x.EmployeeID==id).ToList();
            var per=c.Employees.Where(x=>x.EmployeeID==id).Select(y=>y.EmployeeName+" "+y.EmployeeSurname).FirstOrDefault(); 
            ViewBag.dper=per;
            return View(degerler1);
        }

    }
}