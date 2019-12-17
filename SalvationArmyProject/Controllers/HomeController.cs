using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Models;
using SalvationArmyProject.ViewModels;
using SalvationArmyProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SalvationArmyProject.Controllers
{
    public class HomeController : Controller
    {
        private IEventRepository _iEventRepository;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(IEventRepository iEventRepository, SignInManager<IdentityUser> signInManager) {
            _iEventRepository = iEventRepository;
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult newHelp()
        {
            IEnumerable<Event> events = _iEventRepository.allEvents();
            ViewData["events"] = events;
            return View(events);
        }

        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult Help()
        {
            IEnumerable<Event> events = _iEventRepository.allEvents();
            ViewData["events"] = events;
            return View(events);
        }

        public IActionResult Volunteers() {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult Admin()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Admin(EventResponseViewModel eventResponse)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
