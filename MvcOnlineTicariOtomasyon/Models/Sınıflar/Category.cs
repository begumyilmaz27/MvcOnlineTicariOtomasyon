using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Category
    {
        //Sınıflara değişkenlerle erişemiyoruz. bize property lazım. bu sayede Category tablomuza CategoryID ve CategoryName ekleyebileceğiz.
        //entityFrameWork yaklaşımında temel CRUD işlemlerini yani listeleme, ekleme, silme ve güncelleme işlemi gerçekleştirirken mutlaka anahtara ihtiyacımız var yani PRİMARYKEY bu yüzden [Key] diyoruz. Üzerinde bulunduğu değişkeni birincil anahtar yapıyor yani CategoryID'yi

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName  { get; set; }
    }
}