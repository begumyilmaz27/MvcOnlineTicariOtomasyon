using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }//1234123AB 
        //Tracking Code: KArgo Takip demek

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Employee { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Receiver { get; set; }
        //receiver: alıcı demek

        public DateTime Tarih { get; set; }
    }
}