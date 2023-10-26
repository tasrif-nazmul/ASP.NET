using ProductsProcess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ProductsProcess.Controllers
{
    public class CustomerController : Controller
    {
      

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var db = new ProductsProcessEntities3();
            var match = db.Customers.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (match != null) 
            {
                Session["CustomerID"] = match.CustomerID;
                Session["CustomerUsername"] = match.Username;
                return RedirectToAction("ViewProduct");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
            
        }

        public ActionResult ViewProduct()
        {
            if (Session["CustomerID"] == null)
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
    }
}