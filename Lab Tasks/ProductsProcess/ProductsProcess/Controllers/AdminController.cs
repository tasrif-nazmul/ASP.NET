using ProductsProcess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsProcess.Controllers
{
    public class AdminController : Controller
    {
     

        public ActionResult Dashboard()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
                var db = new ProductsProcessEntities3();
                return View(); 
        }
        
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new ProductsProcessEntities3();
            var matchs = db.Admins.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (matchs != null) 
            {
                Session["AdminID"] = matchs.AdminID;
                Session["AdminEmail"] = matchs.Email;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("","Invalid email or password");
                return View();
            }
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }

            else
            {
                var db = new ProductsProcessEntities3();
                return View();
            }
            
        }
        
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }

            else
            {
                var db = new ProductsProcessEntities3();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
        }

        public ActionResult ViewProduct()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var db = new ProductsProcessEntities3();
                var data = db.Products.ToList();
                return View(data);
            }
            
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }

            else
            {
                var db = new ProductsProcessEntities3();
                var exData = (from d in db.Products where d.ProductID == id select d).SingleOrDefault();
                return View(exData);
            }
            
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }

            else
            {
                var db = new ProductsProcessEntities3();
                var exData = db.Products.Find(p.ProductID);
                exData.Name = p.Name;
                exData.Price = p.Price;
                exData.Description = p.Description;
                db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            
        }
        
        public ActionResult DeleteProduct(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Login");
            }

            else
            {
                var db = new ProductsProcessEntities3();
                var exData = db.Products.Find(id);
                db.Products.Remove(exData);
                db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            
        }
    }
}