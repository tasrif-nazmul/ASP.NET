using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
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

        [Logged]
        [HttpPost]
        public ActionResult AddEmployee(Regestration r)
        {
            if (ModelState.IsValid)
            {

                var db = new ZeroHungerEntities1();

                if (db.Regestrations.Any(e => e.Email == r.Email))
                {
                    ModelState.AddModelError("Email", "This Email already used, try another email");
                    return View(r);
                }

                

                if (r.Role == "admin")
                {
                    var NGOEntity = new NGO
                    {
                        Name = r.Name,
                        Email = r.Email,
                        Password = r.Password,
                        Role = r.Role
                    };
                    db.NGOs.Add(NGOEntity);
                    db.SaveChanges();
                }
                else if (r.Role == "employee")
                {
                    var EmployeeEntity = new Employee
                    {
                        Name = r.Name,
                        Email = r.Email,
                        Password = r.Password,
                        Role = r.Role
                    };
                    db.Employees.Add(EmployeeEntity);
                    db.SaveChanges();
                }

                var RegestrationEntity = new Regestration
                {
                    Name = r.Name,
                    Email = r.Email,
                    Password = r.Password,
                    Role = r.Role
                };
                db.Regestrations.Add(RegestrationEntity);
                db.SaveChanges ();
                return RedirectToAction("Index");

            }

            else
            {
                ModelState.AddModelError("", "Please fill in all required fields.");
                return View(r);
            }
            //return View(r);
        }


        [Logged]
        public ActionResult ViewRequest()
        {
            var db = new ZeroHungerEntities1();
            var data = db.CollectionRequests.Where(cr => cr.Status == "Requesting").ToList();
            return View(data);
        }
        
        [Logged]
        public ActionResult CompletedRequest()
        {
            var db = new ZeroHungerEntities1();
            var data = db.CollectionRequests.Where(cr => cr.Status == "Accepted").ToList();
            return View(data);
        }
        
       
        
        [Logged]
        [HttpGet]
        public ActionResult RejectRequest(int id)
        {
            var db = new ZeroHungerEntities1();
            var exStatus = db.CollectionRequests.FirstOrDefault(n=> n.CollectionRequestID == id);
            return View(exStatus);
        }
        
        [Logged]
        [HttpPost]
        public ActionResult RejectRequest(CollectionRequest cr)
        {
            var db = new ZeroHungerEntities1();
            var exData = db.CollectionRequests.Find(cr.CollectionRequestID);
            exData.Status = "Rejected";
            db.SaveChanges();
            return RedirectToAction("ViewRequest");
        }



        //trash
        [Logged]
        public ActionResult RejectedRequest()
        {
            var db = new ZeroHungerEntities1();
            var data = db.CollectionRequests.Where(cr => cr.Status == "Rejected").ToList();
            return View(data);    
        }

        [Logged]
        [HttpGet]
        public ActionResult AcceptRequest(int id)
        {
            var db = new ZeroHungerEntities1();
            var ExData = db.CollectionRequests.FirstOrDefault(n => n.CollectionRequestID == id);
            return View(ExData);
        }

        [Logged]
        [HttpPost]
        public ActionResult AcceptRequest(CollectionRequest cr)
        {
            var db = new ZeroHungerEntities1();
            var exData = db.CollectionRequests.Find(cr.CollectionRequestID);
            exData.Status = "Processing";
            exData.EmployeeID = cr.EmployeeID;
            db.SaveChanges();
            return RedirectToAction("ViewRequest");
        }

        [Logged]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}