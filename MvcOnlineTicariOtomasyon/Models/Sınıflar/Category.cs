using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName  { get; set; }

        //----------------------------------------------------------------------------

        //category tablosunda birden fazla ürün olabilir. ve int değil ıcollection kullandık çünkü birden fazla şey tutacak bir yapıya ihtiyacımız var. interface'dir ıcollection yapısı. ↓ ↓ ↓
        public ICollection<Product> Products { get; set; }
    }
}