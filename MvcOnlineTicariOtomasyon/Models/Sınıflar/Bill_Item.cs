using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Bill_Item
    {
        //bill item= fatura kalem demek


        [Key]
        public int Bill_ItemID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        //Quantity=miktar
        public decimal UnitQuantities { get; set; }
        //UnitQuantities=birim miktar
        public decimal Amount { get; set; }
        //Amount=tutar


    }
}