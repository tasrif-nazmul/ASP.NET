using ProductCategory.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCategory.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ShowProduct()
        {
            var db = new ProCatEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            var db = new ProCatEntities();
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            var db = new ProCatEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("ShowProduct");
        }

        [HttpGet]
        public ActionResult Edit(int ID) 
        {
            var db = new ProCatEntities();
            var ex = (from d in db.Products
                      where d.id == ID
                      select d).SingleOrDefault();
            return View(ex);
        }
        [HttpPost]
        public ActionResult Edit(Product p) 
        {
            var db = new ProCatEntities();
            var exdata = db.Products.Find(p.id);
            exdata.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("ShowProduct");
        }
        
        public ActionResult Delete(int id) 
        {
            var db = new ProCatEntities();
            var ExObj = db.Products.Find(id);
            db.Products.Remove(ExObj);
            db.SaveChanges();
            return RedirectToAction("ShowProduct");
        }
    }
}