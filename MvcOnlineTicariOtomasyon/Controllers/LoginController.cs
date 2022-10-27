using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current p)
        {
            c.Currents.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current p)
        {
            var bilgiler = c.Currents.FirstOrDefault(x => x.CurrentMail == p.CurrentMail && x.CurrentPassword == p.CurrentPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
                Session["CurrentMail"] = bilgiler.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel"); //beni CurrentPanel'in Index aksiyonuna yönlendir
            }
            else
            {
                return RedirectToAction("Index", "Login"); //Yanlışsa baştaki Login sayfasına gönder
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin p) //parantez içine parametre yolluyoruz Admin tablosundan
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminUserName, false);
                Session["AdminUserName"] = bilgiler.AdminUserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}