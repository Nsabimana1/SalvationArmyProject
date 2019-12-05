using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Entities;
using SalvationArmyProject.Services;
using SalvationArmyProject.ViewModels;

namespace SalvationArmyProject.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository _iEventRepository;
        public EventController(IEventRepository iEventRepository) {
            _iEventRepository = iEventRepository;
        }
        [HttpGet]
        public IActionResult EventRequest(string eventName)
        {
            TempData["EventName"] = eventName;
            return View();
        }
        [HttpGet]
        public IActionResult EventAddition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EventAddition(EventAdditionViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var eventT = new Event()
                {
                    eventId = new Guid(),
                    eventName = eventModel.eventName,
                    eventDescription = eventModel.eventDescription,
                    eventDateTime = eventModel.eventDateTime,
                    eventDuration = eventModel.eventDuration,
                    eventRequests = new List<EventRequest>(),
                };
                this._iEventRepository.addEvent(eventT);
                return RedirectToAction("admin", "home");
            }

            return View(eventModel);
        }
    }
}
