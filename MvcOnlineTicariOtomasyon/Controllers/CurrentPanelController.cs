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
        // GET:
        // 
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            //CariMail'den gelen mail'i Session değeri olarak tutucam ve işlemleri CariMail'e göre yapıcam.

            var mail = (string)Session["CurrentMail"];
            var degerler = c.Messages.Where(x => x.Receiver == mail).ToList();
            ViewBag.m = mail;

            //örneğin 1 numaralı ID sisteme giriş yaptı ve yaptığı satış hareketi görmek istiyor. 1 numaralı ID'ye ulaşmamızı sağlayan sorgu;
            var mailid = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            ViewBag.mid = mailid;

            //Toplamda kaç farklı satış yapılmışi?
            var toplamsatis = c.SalesMovements.Where(x => x.CurrentID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            //Satış Harekette CariID'nin toplam ne kadar satış yapacağını bulacağız
            var toplamtutar = c.SalesMovements.Where(x => x.CurrentID == mailid).Sum(y => y.SalesMovement_TotalAmount);
            ViewBag.toplamtutar = toplamtutar;
            //Toplam Urun Sayısını bulacağız
            var toplamurunsayisi = c.SalesMovements.Where(x => x.CurrentID == mailid).Sum(y => y.SalesMovement_Piece);
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            //Ad-Soyadı listeleyeceğız Index kısmında Foreach dönhüsü ile. 
            var adsoyad = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);

        }

        [Authorize]
        public ActionResult MyOrders() //Siparişlerim bölümü Browserdaki
        {
            var mail = (string)Session["CurrentMail"]; //CurrentMail e göre session değeri oluşturucaz. 
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault(); 
            
            //Cariler içindeki x.CurrentMail diyerek mail adresi dışarıdan gelene (mail dediğimiz) eşit olanlar içinden CurrentID'ye göre al ve FirstOrDefault diyerek getir.

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
            //yukarı mesajlardan ürettiğimiz m parametresi mesajlar tablosunda (SQL tarafındaki ) yer alan Date sütununa ya ad C#'daki karşılığı ile property'sine  kısa tarih formatında atama gerçekleştirdik. 

            m.Sender = mail;

            c.Messages.Add(m); //Context sınıfından ürettiğimiz c nesnesine m parametresinden gelen değeri ekleyeceksin
            c.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var k = from x in c.CargoDetails select x;
            k = k.Where(y => y.TrackingCode.Contains(p));
            return View(k.ToList());
        }

        public ActionResult CurrentCargoTracking(string id)
        {
            var degerler = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //çıkış yap
            Session.Abandon(); //istekleri terk et
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            var caribul = c.Currents.Find(id);
            return PartialView("Partial1", caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Messages.Where(x => x.Sender == "Admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Current cr)
        {
            var cari = c.Currents.Find(cr.CurrentID);
            cari.CurrentName = cr.CurrentName;
            cari.CurrentSurname = cr.CurrentSurname;
            cari.CurrentPassword = cr.CurrentPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}