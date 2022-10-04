using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SalesMovement
    {
        //SalesMovement=satış hareketi

        //Ürün<Product
        //Cari<Current
        //Personel<Employee

        [Key]
        public int SalesMovement_SalesID { get; set; }
        public int  SalesMovement_Piece { get; set; }
        public DateTime SalesMovement_Date { get; set; }
        public decimal SalesMovement_Price { get; set; }
        public decimal SalesMovement_TotalAmount { get; set; }
        

        //----------------------------------------------------------------------------

        //Birden fazla kez olacak. Satış hareket birden fazla PRoduct-employee-curreent içerebilir. 
        public Product Products { get; set; }
        public Current Currents { get; set; }
        public Employee Employees { get; set; }


    }
}