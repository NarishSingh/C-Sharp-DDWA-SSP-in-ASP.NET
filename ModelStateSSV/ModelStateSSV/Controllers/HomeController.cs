using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelStateSSV.Models;

namespace ModelStateSSV.Controllers
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
            //name
            if (string.IsNullOrEmpty(model.ClientName))
            {
                ModelState.AddModelError("ClientName", "Please enter your name.");
            }

            //date
            if (ModelState.IsValidField("Date"))
            {
                if (model.Date < DateTime.Today.AddDays(1))
                {
                    ModelState.AddModelError("Date", "Appointments cannot be made same day or in past");
                }
                else if (model.Date.DayOfWeek == DayOfWeek.Saturday || model.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("Date", "We are not open on the weekend");
                }
            }
            else
            {
                ModelState.AddModelError("Date", "Please enter a valid date");
            }

            //terms declined
            if (!model.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "Please accept terms and conditions to book an appointment");
            }

            return View(ModelState.IsValid
                ? "Confirmation"
                : "Index", model);
        }
    }
}