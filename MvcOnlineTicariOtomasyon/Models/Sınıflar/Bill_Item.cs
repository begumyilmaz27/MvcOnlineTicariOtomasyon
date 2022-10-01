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
        public string BillDescription { get; set; }
        public int BillQuantity { get; set; }
        //Quantity=miktar
        public decimal BillUnitQuantities { get; set; }
        //UnitQuantities=birim miktar
        public decimal BillAmount { get; set; }
        //Amount=tutar


    }
}