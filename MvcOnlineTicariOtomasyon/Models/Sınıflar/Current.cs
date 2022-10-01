using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Current
    {        

        [Key]    
        public int CurrentID { get; set; }
        public int CurrentName { get; set; }
        public int CurrentSurname { get; set; }
        public int CurrentCity { get; set; }
        public int CurrentMail { get; set; }
         
    
    }
}