using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult EmployeeBring(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanName,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Employees.Find(id);
            return View("EmployeeBring", prs); ;
        }
        public ActionResult EmployeeUpdate(Employee p)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "~/Image/" + dosyaadi + uzanti;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            //}
            var prsn = c.Employees.Find(p.EmployeeID);
            prsn.EmployeeName = p.EmployeeName;
            prsn.EmployeeSurname = p.EmployeeSurname;
            prsn.EmployeeImage = p.EmployeeImage;
            prsn.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var sorgu = c.Employees.ToList();
            return View(sorgu);
        }




    }
}