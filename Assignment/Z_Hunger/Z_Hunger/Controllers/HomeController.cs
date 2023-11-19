using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z_Hunger.Auth;
using Z_Hunger.EF;

namespace Z_Hunger.Controllers
{
    public class HomeController : Controller
    {
        [Logged]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new ZeroHungerEntities1();
            var matchs = db.Regestrations.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (matchs != null)
            {
                

                if (matchs.Role == "employee")
                {
                    Session["EmployeeEmail"] = email;
                    int EmployeeID = db.Employees.Where(u => u.Email == email).SingleOrDefault().EmployeeID;
                    Session["EmployeeID"] = EmployeeID;
                    return RedirectToAction("Index", "Employee");
                }

                else if (matchs.Role == "admin")
                {
                    Session["email"] = email;
                    return RedirectToAction("Index", "NGO");
                }
                
                else if (matchs.Role == "restaurant")
                {
                    Session["RestaurantEmail"] = email;
                    int restaurantID = db.Restaurants.Where(u => u.RestauranEmail == email).SingleOrDefault().RestaurantID;
                    Session["RestaurantID"] = restaurantID;
                    Session["RestaurantID"] = restaurantID;
                    return RedirectToAction("Index", "Restaurant");
                }
                return RedirectToAction("Login");
            }

            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
            }

            return View();
        }
    }
}