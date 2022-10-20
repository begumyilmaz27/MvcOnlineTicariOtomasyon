using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Class1
    {
        //productDetailController' da oluşturduğumuz Deger1 ve Deger2 
        // deger1 ile Products üzerinden ProductID'yi listelemeye 
        // deger2 ile Details üzerinden DetayID'yi listelemeyi hedefledik.
        public IEnumerable<Product> Deger1 { get; set; }
        public IEnumerable<Detail> Deger2 { get; set; }        
        public IEnumerable<Current> Deger3 { get; set; }
    }
}