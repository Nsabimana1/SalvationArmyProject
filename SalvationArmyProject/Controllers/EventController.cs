using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Services;

namespace SalvationArmyProject.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository _ieventRepository;
        public EventController(IEventRepository ieventRepository) {
            _ieventRepository = ieventRepository;
        }

        public IActionResult EventRequest(string eventName)
        {
            TempData["EventName"] = eventName;
            return View();
        }
    }
}
