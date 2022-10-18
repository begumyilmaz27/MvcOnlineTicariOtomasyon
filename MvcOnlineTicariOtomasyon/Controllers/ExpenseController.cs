using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Expenses.ToList();
            return View(degerler);
        }
    }
}