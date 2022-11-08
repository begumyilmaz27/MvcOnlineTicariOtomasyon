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
            var degerler = c.Bill_Items.Where(x => x.BillID == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewBill_Item()
        {
            return View();
        }
        public ActionResult NewBill_Item(Bill_Item p)
        {
            c.Bill_Items.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dynamic()
        {
            Class5 cs = new Class5();
            cs.deger1 = c.Bills.ToList();
            cs.deger2 = c.Bill_Items.ToList();
            return View(cs);
        }
        //public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        //{
        //    Faturalar f = new Faturalar();
        //    f.FaturaSeriNo = FaturaSeriNo;
        //    f.FaturaSıraNo = FaturaSıraNo;
        //    f.Tarih = Tarih;
        //    f.VergiDairesi = VergiDairesi;
        //    f.Saat = Saat;
        //    f.TeslimEden = TeslimEden;
        //    f.TeslimAlan = TeslimAlan;
        //    f.Toplam = decimal.Parse(Toplam);
        //    c.Faturalars.Add(f);
        //    foreach (var x in kalemler)
        //    {
        //        FaturaKalem fk = new FaturaKalem();
        //        fk.Aciklama = x.Aciklama;
        //        fk.BirimFiyat = x.BirimFiyat;
        //        fk.Faturaid = x.FaturaKalemid;
        //        fk.Miktar = x.Miktar;
        //        fk.Tutar = x.Tutar;
        //        c.FaturaKalems.Add(fk);
        //    }
        //    c.SaveChanges();
        //    return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        //}








    }
}