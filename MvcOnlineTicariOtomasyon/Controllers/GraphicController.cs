using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            //1. satır >>>>>> Grafik çiz diyerek değişken oluşturduk parantez içinde genişlik ve yükseklik değerleini verdik 
            //2. satır >>>>>> Write metodu ile ekrana yazdırıyor
            //3. satır >>>>>> Dosya döndürme şeklini yazıyoruz burada

            var grafikciz = new Chart(600, 600); 
            grafikciz.AddTitle("Category - Product Stock").AddLegend("Stock").AddSeries("Values", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write(); 
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg"); 
        }

        Context c = new Context();

        public ActionResult Index3()
        {
            //x ve y değerlerini tutması için ArrayList sınıfını kullandık
            //x values ve y values nesneleri oluşturduk

            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            //sonuclar isminde değişken oluşturduk. bunun için yukarıda contextten nesne ürettik ve MvcOnlineTicariOtomasyon.Models.Sınıflar; ekledik tepeye
            var sonuclar = c.Products.ToList();

            //xvalue listesine x'den gelen ProductName değerini listeledik
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.ProductStock));

            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);

            //geriye return file diyerek grafik değeri döndür dedik.
            //grafik yazarak grafik formatında ToWebImage diyerek Image formatına döndürdük
            //GetBytes diyerek Bytes formarında alıcaz                             
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        //Visualize görselleştirmek için kullanılıyor
        //geriye json döndürüyor
        //GoogleChartta görselleştirmeye ulaşmak için JsonRequestBehavior.AllowGet kullanmak gerekiyor

        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> Urunlistesi()
        {
            List<Sinif1> snf = new List<Sinif1>();

            snf.Add(new Sinif1()
            {
                productname = "Bilgisayar",
                stock = 120
            });
            snf.Add(new Sinif1()
            {
                productname = "Beyaz Eşya",
                stock = 150
            });
            snf.Add(new Sinif1()
            {
                productname = "Mobilya",
                stock = 70
            });
            snf.Add(new Sinif1()
            {
                productname = "Küçük Ev Aletleri",
                stock = 180
            });
            snf.Add(new Sinif1()
            {
                productname = "Mobil Cihazlar",
                stock = 90
            });
            return snf;
        }



        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> UrunListesi2()
        {
            //List türündeki sınıftan nesne türeterek başlıyoruz.
            //Context kısmını farklı şekilde parantez içinde aldık burada

            List<Sinif2> snf = new List<Sinif2>();
            using (var c = new Context())
            {
                snf = c.Products.Select(x => new Sinif2
                {
                    //Sinif2 ye bağlı olan yere atama yapıyoruz burada

                    product2 = x.ProductName,
                    stock2 = x.ProductStock

                }).ToList();
            }
            return snf;
        }


    }
}