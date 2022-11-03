using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //Arama kısmını tanımlıyoruz burada. Browserda çıkan Cargo Tracking Code kısmına kod yazdığımızda o kodlu kargonun çıkması için yaptık bu kısmı
            //Index'de Search diye tanımladığımız kısım

            var k = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TrackingCode.Contains(p));
            }
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);

            int s1, s2, s3; //Sayının 1. bölümü, 2. bölümü, 3. bölümü demek

            //1. kısım 3 basamaklı bir bölüm olsun
            s1 = rnd.Next(100, 1000);//10--> 3 1 2 1 2 1
            //s2'den 2 karakter gelecek
            s2 = rnd.Next(10, 99);
            //s3'den 2 karakter gelecek
            s3 = rnd.Next(10, 99);

            //string bir dizi oluşturucaz ve s1 s2 s3 ü buraya toplicaz birleştircez.
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];

            //viewbag ile NewCargo View'ına taşıcaz bunları. Sayfamız yüklendiği zaman takip kodunu NewCargo'da görüntüleyebilmeliyiz.
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult NewCargo(CargoDetail d)
        {
            c.CargoDetails.Add(d);
            c.SaveChanges(); 
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            //p = "489A15B86D";
            var degerler = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);

            //CargoTracking:Kargo Takip demek
            //Tracking Code: Takip kodu
        }
    }
}