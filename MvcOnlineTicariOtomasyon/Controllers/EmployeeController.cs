using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Employees.ToList();
            return View(degerler);

            //Where(x => x.CurrentSituation == true)
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanName,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee p)
        {
            //p.CurrentSituation = true;
            c.Employees.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}