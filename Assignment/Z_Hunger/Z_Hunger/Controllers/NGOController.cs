using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Z_Hunger.Auth;
using Z_Hunger.EF;

namespace Z_Hunger.Controllers
{
    public class NGOController : Controller
    {
        [Logged]
        public ActionResult Index()
        {
            return View();
        }


        [Logged]
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(NGO n)
        {
            if (ModelState.IsValid)
            {

                var db = new ZerooHungerEntities();

                if (db.NGOs.Any(e => e.Email == n.Email))
                {
                    ModelState.AddModelError("Email", "This Email already used, try another email");
                    return View(n);
                }

                if (n.Password != n.ConfirmPass)
                {
                    ModelState.AddModelError("ConfirmPass", "Must same as Password");
                    return View(n);
                }


                

                db.NGOs.Add(n);
                db.SaveChanges();
                //return View(n);
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
            }
            return View(n);
        }

        public ActionResult Employee()
        {
            return View();
        }
    }
}