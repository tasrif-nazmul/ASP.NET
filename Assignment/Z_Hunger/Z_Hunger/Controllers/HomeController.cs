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

                if (matchs.Role == "admin")
                {
                    Session["Email"] = email;
                    int NGOid = db.NGOs.Where(n => n.Email == email).SingleOrDefault().NGOid;
                    Session["NGOid"] = NGOid;
                    return RedirectToAction("Index", "NGO");
                }

                else if (matchs.Role == "employee")
                {
                    Session["EmployeeEmail"] = email;
                    int EmployeeID = db.Employees.Where(e => e.Email == email).SingleOrDefault().EmployeeID;
                    Session["EmployeeID"] = EmployeeID;
                    return RedirectToAction("Index", "Employee");
                }
                
                else if (matchs.Role == "restaurant")
                {
                    Session["RestaurantEmail"] = email;
                    int restaurantID = db.Restaurants.Where(r => r.RestauranEmail == email).SingleOrDefault().RestaurantID;
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