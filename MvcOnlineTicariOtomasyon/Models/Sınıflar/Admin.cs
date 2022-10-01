using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; } 
        public string AdminUserName { get; set; } 
        public string AdminPassword { get; set; } 
        public string AdminAuthority { get; set; }
        //yetki=authority
    }
}