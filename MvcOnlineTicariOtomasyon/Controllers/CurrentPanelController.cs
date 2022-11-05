using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"]; //CariMail'den gelen mail'i Session değeri olarak tutucam ve işlemleri CariMail'e göre yapıcam.

            var degerler = c.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(degerler);

            //var degerler = c.mesajlars.Where(x => x.Alici == mail).ToList();


            //var mailid = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            //ViewBag.mid = mailid;
            //var toplamsatis = c.SalesMovements.Where(x => x.CurrentID == mailid).Count();
            //ViewBag.toplamsatis = toplamsatis;
            //var toplamtutar = c.SalesMovements.Where(x => x.CurrentID == mailid).Sum(y => y.SalesMovement_TotalAmount);
            //ViewBag.toplamtutar = toplamtutar;
            //var toplamurunsayisi = c.SalesMovements.Where(x => x.CurrentID == mailid).Sum(y => y.SalesMovement_Piece);
            //ViewBag.toplamurunsayisi = toplamurunsayisi;
            //var adsoyad = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            //ViewBag.adsoyad = adsoyad;


        }
        [Authorize]
        public ActionResult MyOrders() //Siparişlerim bölümü Browserdaki
        {
            var mail = (string)Session["CurrentMail"]; //CurrentMail e göre session değeri oluşturucaz. 
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault(); //Cariler içindeki x.CurrentMail diyerek mail adresi dışarıdan gelene (mail dediğimiz) eşit olanlar içinden CurrentID'ye göre al ve FirstOrDefault diyerek getir.
            var degerler = c.SalesMovements.Where(x => x.CurrentID == id).ToList();
            return View(degerler);

            //1. kod; Sisteme giriş yapan mail adresini Session'a atadık.
            //2. kod; ID isminde bir değişken oluşturduk ve sisteme giriş yapan MAİL adresinin ID'sini alan kodu yazdık
            //3. SatışHareket tablosuna gittik. Getirdiğimiz ID, SatışHareket tablosundaki ID'ye eşit olanı bulan kodu yazdık ve listeledik
            //4. Geriye döndür dedik. 
        }



        [Authorize]
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var mesajlar = c.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MesajID).ToList();
                //where şartı ile alıcı kısmında mail değişkenine eşit olanları ToList yapacak.
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var mesajlar = c.Messages.Where(x => x.Sender == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var degerler = c.Messages.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var mail = (string)Session["CurrentMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }
        //public ActionResult CargoTracking(string p)
        //{
        //    var k = from x in c.KargoDetays select x;
        //    k = k.Where(y => y.TakipKodu.Contains(p));
        //    return View(k.ToList());
        //}

        //public ActionResult CariKargoTakip(string id)
        //{
        //    var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
        //    return View(degerler);
        //}
        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon();
        //    return RedirectToAction("Index", "Login");
        //}
        //public PartialViewResult Partial1()
        //{
        //    var mail = (string)Session["CariMail"];
        //    var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariid).FirstOrDefault();
        //    var caribul = c.Carilers.Find(id);
        //    return PartialView("Partial1", caribul);
        //}
        //public PartialViewResult Partial2()
        //{
        //    var veriler = c.mesajlars.Where(x => x.Gonderici == "admin").ToList();
        //    return PartialView(veriler);
        //}
        //public ActionResult CariBilgiGuncelle(Cariler cr)
        //{
        //    var cari = c.Carilers.Find(cr.Cariid);
        //    cari.CariAd = cr.CariAd;
        //    cari.CariSoyad = cr.CariSoyad;
        //    cari.CariSifre = cr.CariSifre;
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}