﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c=new Context();   //Contextten ürettiğimiz C nesnesi 
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        { 
            return View();         
        }
        
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult CategoryDelete(int id)
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var ctgB = c.Categories.Find(id);
            return View("CategoryBring",ctgB);
        }
        public ActionResult CategoryUpdate(Category k)
        {
            var ctgU = c.Categories.Find(k.CategoryID);
            ctgU.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}