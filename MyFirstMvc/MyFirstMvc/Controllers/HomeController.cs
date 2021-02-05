using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMvc.Models;

namespace MyFirstMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrentDt = DateTime.Now; //use vb obj to send data to views, just add members
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult Weather()
        {
            // This is where we would read weather data from a database or service
            Weather weather = new Weather
            {
                Date = DateTime.Now, 
                High = 75, 
                Low = 62, 
                Description = "Cloudy"
            };

            return View(weather); //to pass data by obj, feed it as param to View(), but NOTE can only take one obj at a time
        }
    }
}