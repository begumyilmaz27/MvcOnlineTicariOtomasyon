using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Marka { get; set; }
        public short Stock { get; set; }

        //C# daki short'un SQL tarafındaki karşılığı smallint. 2byte büyüklüğünde

        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

        //Ürünlerin durumlarıyla ilgili kritik seviyeler belirleyeceğiz.Örneğin şu değerin altına düştü mü düşmedi mi gibi. Bu yüzden Bool veri tipi kullanacağız.
        public bool Situation { get; set; }     
        public string ProductImage { get; set; }

    }
}   