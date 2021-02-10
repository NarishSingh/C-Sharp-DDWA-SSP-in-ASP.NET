using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributesSSV.Models;

namespace AttributesSSV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ApptRequest());
        }

        [HttpPost]
        public ActionResult Index(ApptRequest model)
        {
            if (ModelState.IsValid)
            {
                return View("Confirmation", model);
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}