using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Z_Hunger.Auth;
using Z_Hunger.EF;

namespace Z_Hunger.Controllers
{
    public class EmployeeController : Controller
    {

        [ELogged]
        public ActionResult Index()
        {
            int EmployeeID = (int)Session["EmployeeID"];
            var db = new ZeroHungerEntities1();
            var data = db.CollectionRequests.Where(e => e.EmployeeID == EmployeeID && e.Status == "Processing").ToList();
            db.SaveChanges();
            return View(data);
        }

        [ELogged]
        [HttpGet]
        public ActionResult AcceptRequest(int id)
        {
            var db = new ZeroHungerEntities1();
            var ExData = db.CollectionRequests.FirstOrDefault(n => n.CollectionRequestID == id);
            return View(ExData);
        }

        [ELogged]
        [HttpPost]
        public ActionResult AcceptRequest(CollectionRequest cr)
        {
            var db = new ZeroHungerEntities1();
            var exData = db.CollectionRequests.Find(cr.CollectionRequestID);
            exData.Status = "Accepted";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ELogged]
        public ActionResult CompletedRequest(CollectionRequest cr)
        {
            int EmployeeID = (int)Session["EmployeeID"];
            var db = new ZeroHungerEntities1();
            var data = db.CollectionRequests.Where(e => e.EmployeeID == EmployeeID && e.Status == "Accepted").ToList();
            db.SaveChanges();
            return View(data);
        }

        [ELogged]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

    }
}