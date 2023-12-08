using BuyProduct.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BuyProduct.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var db = new ProCatEntities();

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string email, string password) 
        {
            var db = new ProCatEntities();
            var user = db.Regesters.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Products", "Product");
            }

            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Products() 
        {
            var db = new ProCatEntities();
            var data = db.Products.ToList();
            return View(data);
        }
    }
}