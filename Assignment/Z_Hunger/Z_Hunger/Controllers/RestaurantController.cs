using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Z_Hunger.Auth;
using Z_Hunger.EF;

namespace Z_Hunger.Controllers
{
    public class RestaurantController : Controller
    {
        [RLogged]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RegesterRestaurant()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegesterRestaurant(Regestration r)
        {
            if (ModelState.IsValid)
            {

                var db = new ZeroHungerEntities1();
                if(db.Regestrations.Any(s=> s.Email== r.Email))
                {
                    ModelState.AddModelError("RestauranEmail", "This Email already used, try another Email");
                    return View(r);
                }


                var restaurantEntity = new Restaurant
                {
                    Name = r.Name,
                    RestauranEmail = r.Email,
                    Password = r.Password,
                    ConfirmPass = r.Password
                };

                var regestrationEntity = new Regestration
                {
                    Name = r.Name,
                    Email = r.Email,
                    Password = r.Password,
                    Role = r.Role
                };

                db.Restaurants.Add(restaurantEntity);
                db.SaveChanges();

                db.Regestrations.Add(regestrationEntity);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
            }

            return View(r);
        }

        [RLogged]
        [HttpGet]
        public ActionResult CreateRequest()
        {
            return View();
        }

        [RLogged]
        [HttpPost]
        public ActionResult CreateRequest(string IteamName, string ExpiredTime, string status)
        {
            int RestaurantID = (int)Session["RestaurantID"];
            if (ModelState.IsValid)
            {

                var db = new ZeroHungerEntities1();

                var cr = new CollectionRequest
                {
                    IteamName = IteamName,
                    CreationTime = DateTime.Now.ToString(),
                    ExpiredTime = ExpiredTime,
                    RestaurantID = RestaurantID,
                    Status = "requesting"
                };

                db.CollectionRequests.Add(cr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
                return View();
            }

        }

    }
}