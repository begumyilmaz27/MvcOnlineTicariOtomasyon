using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill_Item> Bill_Items { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Current> Currents{ get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Expense> Expenses{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SalesMovement> SalesMovements{ get; set; }
        public DbSet<Detail> Details{ get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }   
        public DbSet<CargoDetail> CargoDetails { get; set; }   
        public DbSet<CargoTracking> CargoTrackings { get; set; }   
        public DbSet<Message> Messages { get; set; }   


    }
}