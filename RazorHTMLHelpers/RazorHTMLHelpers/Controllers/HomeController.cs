using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazorHTMLHelpers.Models;

namespace RazorHTMLHelpers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Students()
        {
            List<Student> allStudents = StudentRepo.ReadAllStudents();

            return View(allStudents);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            return View(model);
        }
    }
}