using ProductsProcess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult Regester()
        {
            var db = new eCommerceEntities();
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Regester(Admin a)
        {
            var db = new eCommerceEntities();

            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if (string.IsNullOrWhiteSpace(a.Name) || string.IsNullOrWhiteSpace(a.Email) || string.IsNullOrWhiteSpace(a.Password))
            {
                ModelState.AddModelError("", "Must be filled all information");
            }

            else
            {


                if (!Regex.IsMatch(a.Password, passwordPattern))
                {
                    ModelState.AddModelError("Password", "Password must contain at least 1 capital letter, 1 small letter, 1 special character, 1 number, and be at least 8 characters long.");
                }

                if (db.Admins.Any(x => x.Email == a.Email))
                {
                    ModelState.AddModelError("Email", "This Email already taken");
                }
            }
            if (ModelState.IsValid)
            {

                db.Admins.Add(a);
                db.SaveChanges();
                return RedirectToAction("Login");
             }

            return View(a);
        }

        [HttpGet]
        public ActionResult Login()
        {
                var db = new eCommerceEntities();
                return View(); 
        }
        
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
                var exData = db.Products.Find(p.ProductID);
                exData.Name = p.Name;
                exData.Price = p.Price;
                exData.Quantity = p.Quantity;
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
                var db = new eCommerceEntities();
                var exData = db.Products.Find(id);
                db.Products.Remove(exData);
                db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            
        }

    }
}