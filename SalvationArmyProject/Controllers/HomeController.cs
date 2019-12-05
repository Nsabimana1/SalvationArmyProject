using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Models;
using SalvationArmyProject.ViewModels;

namespace SalvationArmyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Volunteers() {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Feedback(FeedbackViewModel feedback)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var content = feedback.feedbackContent;

        //    }
        //}


        public IActionResult Admin()
        {
            return View();
        }

        //public IActionResult EventRequest(string eventName)
        //{
        //    TempData["EventName"] = eventName;
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
