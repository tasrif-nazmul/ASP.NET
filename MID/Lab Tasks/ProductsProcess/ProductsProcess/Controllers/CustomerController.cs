using Microsoft.Ajax.Utilities;
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
        public ActionResult Regester()
        {
            var db = new eCommerceEntities();
            return View();
        }


        [HttpPost]
        public ActionResult Regester(Customer c)
        {
            var db = new eCommerceEntities();

            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if (string.IsNullOrWhiteSpace(c.Name) || string.IsNullOrWhiteSpace(c.Username) || string.IsNullOrWhiteSpace(c.Password))
            {
                ModelState.AddModelError("", "Must be filled all information");
            }

            else
            {


                if (!Regex.IsMatch(c.Password, passwordPattern))
                {
                    ModelState.AddModelError("Password", "Password must contain at least 1 capital letter, 1 small letter, 1 special character, 1 number, and be at least 8 characters long.");
                }

                if (db.Customers.Any(x => x.Username == c.Username))
                {
                    ModelState.AddModelError("Username", "This Username already taken");
                }
            }

            if(ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(c);
        }


        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var db = new eCommerceEntities();
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
                var db = new eCommerceEntities();
                var data = db.Products.ToList();
                return View(data);
            }
            
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var db = new eCommerceEntities();
                var productToAdd = (from d in db.Products where d.ProductID == id select d).SingleOrDefault();
                List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();

                // Check if the product is already in the cart
                var existingProduct = cart.FirstOrDefault(p => p.ProductID == id);
                if (existingProduct != null)
                {
                    // If the product is in the cart, update its quantity
                    existingProduct.Quantity++;
                }
                else
                {
                    // If the product is not in the cart, add it with quantity 1
                    if (productToAdd != null)
                    {
                        productToAdd.Quantity = 1; // Set the initial quantity to 1
                        cart.Add(productToAdd);
                    }
                }

                Session["Cart"] = cart;
                return RedirectToAction("ViewProduct");
            }
        }


        [HttpPost]
        public ActionResult AddToCart(Product p)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewCart()
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login");
            }

            List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();
            return View(cart);
        }


        public ActionResult CancelFromCart(int id)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var cart = Session["Cart"] as List<Product> ?? new List<Product>();
                var productToRemove = cart.FirstOrDefault(p => p.ProductID == id);

                cart.Remove(productToRemove);
                Session["Cart"] = cart;
                return RedirectToAction("ViewCart");
            }
        }

    }
}