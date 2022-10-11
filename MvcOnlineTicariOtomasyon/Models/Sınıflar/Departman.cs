using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanName { get; set; }
        public bool DepartmanSituation { get; set; } // Silme ve Güncelleme İşlemleri için

        //----------------------------------------------------------------------------

        //1 departman birden fazla persornel barındırabilir. ICOLLECTİON ile çalışanları departmana dahil ettik. 
        public ICollection<Employee> Employees { get; set; }
    }
}