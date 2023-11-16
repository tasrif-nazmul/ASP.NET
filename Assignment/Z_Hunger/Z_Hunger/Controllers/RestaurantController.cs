using System;
using System.Collections.Generic;
using System.Linq;
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

        /* [HttpPost]
         public ActionResult RegesterRestaurant(Restaurant r)
         {
             if (ModelState.IsValid)
             {

                 if (r.Password != r.ConfirmPass)
                 {
                     ModelState.AddModelError("ConfirmPass", "Must same as Password");
                     return View(r);
                 }

                 var db = new ZerooHungerEntities();
                 db.Restaurants.Add(r);
                 db.SaveChanges();
                 return RedirectToAction("Index","Home");
             }

             else
             {
                 ModelState.AddModelError("", "Please fill in all required fields.");
             }
             return View(r);
         }*/

        [HttpPost]
        public ActionResult RegesterRestaurant(Restaurant r)
        {
            if (ModelState.IsValid)
            {

                var db = new ZerooHungerEntities();
                if(db.Restaurants.Any(s=> s.RestauranEmail == r.RestauranEmail))
                {
                    ModelState.AddModelError("RestauranEmail", "This Email already used, try another Email");
                    return View(r);
                }

                if (r.Password != r.ConfirmPass)
                {
                    ModelState.AddModelError("ConfirmPass", "Must be the same as Password");
                    return View(r);
                }

                

                var restaurantEntity = new Restaurant
                {
                    Name = r.Name,
                    RestauranEmail = r.RestauranEmail,
                    Password = r.Password,
                    ConfirmPass = r.ConfirmPass
                };

                var ngoEntity = new NGO
                {
                    Name = r.Name,
                    Email = r.RestauranEmail,
                    Password = r.Password,
                    ConfirmPass = r.ConfirmPass,
                    Role = "restaurant"
                };

                db.Restaurants.Add(restaurantEntity);
                db.NGOs.Add(ngoEntity);

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
            }

            return View(r);
        }


        //[HttpGet]
        //public ActionResult CollectRequest()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CollectRequest(string iName, DateTime ct, DateTime et)
        //{
        //    var db = new ZerooHungerEntities();

        //    var cr = new CollectionRequest
        //    {
        //        IteamName = iName,
        //        CreationTime = ct,
        //        ExpiredTime = et,
        //        RestaurantID = Session[],
        //        Status = "Pending"
        //    };

        //    //db.CollectionRequests.Add(cr);
        //    return View();
        //}

    }
}