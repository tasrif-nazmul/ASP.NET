using form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using form.Models;

namespace form.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
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
        public ActionResult Login(Login l )
        {
            if (ModelState.IsValid) {
                //database insertion
                //auth
                //return RedirectToAction("Index");
            }
            return View(l);
        }
    }
}