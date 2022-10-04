using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }

        //----------------------------------------------------------------------

        //1 departman birden fazla persornel barındırabilir. ICOLLECTİON ile çalışanları departmana dahil ettik. Burada da bağladık

        public Departman Departman { get; set; }

        //----------------------------------------------------------------------
        //SalesMovement'dan kurduğumuz bağlantı gereği
        public ICollection<SalesMovement> SalesMovements { get; set; }


    }
}