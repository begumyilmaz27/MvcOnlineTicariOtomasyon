using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class Bill_ItemController : Controller
    {
        // GET: Bill_Item
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Bill_Items.ToList();
            return View();
        }
    }
}