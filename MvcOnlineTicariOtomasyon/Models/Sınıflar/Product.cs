using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }

        public short ProductStock { get; set; }
        //C# daki short'un SQL tarafındaki karşılığı smallint. 2byte büyüklüğünde
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        //Ürünlerin durumlarıyla ilgili kritik seviyeler belirleyeceğiz.Örneğin şu değerin altına düştü mü düşmedi mi gibi. Bu yüzden Bool veri tipi kullanacağız.
        public bool ProductSituation { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }

        public int CategoryId { get; set; } 

        //----------------------------------------------------------------------------

        //Her ürünün sadece bir kategorisi olabilir.  ↓ ↓ ↓ ↓ Category sınıfından bir tane Category değeri aldı
        public virtual Category Category { get; set; }

        //----------------------------------------------------------------------------

        //SalesMovement'dan kurduğumuz bağlantı gereği
        public ICollection<SalesMovement> SalesMovements { get; set; }


    }
}   