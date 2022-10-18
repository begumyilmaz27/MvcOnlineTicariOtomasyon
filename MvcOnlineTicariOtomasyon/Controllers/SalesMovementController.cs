using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesMovementController : Controller
    {
        // GET: SalesMovement
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SalesMovements.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SalesMovementNew()
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View();
        }
        [HttpPost]
        public ActionResult SalesMovementNew(SalesMovement s)
        {
            s.SalesMovement_Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesMovementBring(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SalesMovements.Find(id);
            return View("SalesMovementBring", deger);
        }
        public ActionResult SalesMovementUpdate (SalesMovement p)
        {
            var deger = c.SalesMovements.Find(p.SalesMovement_SalesID);
            deger.CurrentID = p.CurrentID;
            deger.SalesMovement_Piece = p.SalesMovement_Piece;
            deger.SalesMovement_Price = p.SalesMovement_Price;
            deger.EmployeeID = p.EmployeeID;
            deger.SalesMovement_Date = p.SalesMovement_Date;
            deger.SalesMovement_TotalAmount = p.SalesMovement_TotalAmount;
            deger.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}