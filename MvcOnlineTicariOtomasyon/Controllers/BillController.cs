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
        public ActionResult BillBring(int id)
        {
            var fatura = c.Bills.Find(id);
            return View("BillBring", fatura);
        }

        public ActionResult BillUpdate(Bills f)
        {
            var fatura = c.Bills.Find(f.BillID);
            fatura.BillSerialNumber = f.BillSerialNumber;
            fatura.BillSıraNumber = f.BillSıraNumber;
            fatura.BillHour = f.BillHour;
            fatura.BillDate = f.BillDate;
            fatura.BillSubmitter = f.BillSubmitter;
            fatura.BillReceiver = f.BillReceiver;
            fatura.BillTaxAdministration = f.BillTaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillDetail(int id)
        {
            var degerler = c.Bills.Where(x => x.BillID == id).ToList();
            return View(degerler);
        }

    }
}