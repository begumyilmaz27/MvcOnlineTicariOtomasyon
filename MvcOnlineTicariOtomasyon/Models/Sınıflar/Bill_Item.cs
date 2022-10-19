using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Bill_Item
    {
        //bill item= fatura kalem demek

        [Key]
        public int Bill_ItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string BillDescription { get; set; }
        public int BillQuantity { get; set; }
        public decimal BillUnitQuantities { get; set; }
        public decimal BillAmount { get; set; }

        //-------------------------------------------------------------------------

        //Fatura ve FaturaKalem arasında ilişki kurucaz. Yani Bills ve Bill_Item. Bir faturanın birden fazla kalemi olabilir. Bu yüzden Bills den araç ürettik.
        public int BillID { get; set; } 
        public virtual Bills Bills { get; set; }

    }
}