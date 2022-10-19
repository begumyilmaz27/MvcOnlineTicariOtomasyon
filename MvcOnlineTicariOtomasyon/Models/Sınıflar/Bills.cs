using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Bills
    {
        [Key]
        public int BillID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSıraNumber { get; set; }        

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string BillTaxAdministration { get; set; }   

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BillReceiver { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BillSubmitter { get; set; }

        public DateTime BillDate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string BillHour { get; set; }
        

        //ToplamTutar için
        public decimal Total { get; set; }


        //-------------------------------------------------------------------------

        //Fatura ve FaturaKalem arasında ilişki kurucaz. Yani Bills ve Bill_Item. Bir faturanın birden fazla kalemi olabilir. Bu yüzden ICollection kullanıcaz.

        public ICollection<Bill_Item> Bill_Items { get; set; }
    }
}