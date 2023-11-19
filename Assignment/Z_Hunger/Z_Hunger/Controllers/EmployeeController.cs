using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var data = db.CollectionRequests.Where(e => e.EmployeeID == EmployeeID).ToList();
            db.SaveChanges();
            return View(data);
        }
    }
}