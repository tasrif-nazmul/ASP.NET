using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondPractice.Models;

namespace SecondPractice.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Create(Student s) 
        {
            return View(s);
        }
    }
}