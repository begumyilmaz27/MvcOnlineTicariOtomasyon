using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Bills
    {
        [Key]
        public int BillID { get; set; }     
        public string BillSerialNumber { get; set; } 
        public string BillSıraNumber { get; set; } 
        public DateTime BillDate { get; set; }  
        public string TaxAdministration { get; set; }
        //vergi dairesi=Tax Administration
        public DateTime Hour { get; set; }
        public string Receiver { get; set; }
        //Teslim Alan=Receiver
        public string Submitter { get; set; }
        //Gönderen=submitter 

    }
}