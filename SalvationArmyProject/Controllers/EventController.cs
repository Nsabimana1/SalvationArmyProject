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
        private IUserInfoRepository _iUserInfoRepository;

        public EventController(IEventRepository iEventRepository, IUserInfoRepository iUserInfoRepository) {
            _iEventRepository = iEventRepository;
            _iUserInfoRepository = iUserInfoRepository;
        }
        [HttpGet]
        public IActionResult EventRequest(string eventName)
        {
            TempData["EventName"] = eventName;
            return View();
        }

        [HttpPost]
        public IActionResult EventRequest(EventRequestViewModel eventRequestModel)
        {
            if (ModelState.IsValid) {
                var curUserEmail = eventRequestModel.email;
                User userRecord = _iUserInfoRepository.getUserByEmail(curUserEmail);
                userRecord.firstName = eventRequestModel.firstName;
                userRecord.lastName = eventRequestModel.lastName;
                userRecord.phoneNumber = eventRequestModel.phoneNumber;
                _iUserInfoRepository.SaveAllNewChanges();

                EventRequest eventRequest = new EventRequest()
                {
                    eventRequestId = new Guid(),
                    eventFK = eventRequestModel.requestedEventId,
                    eventDescription = "",
                    eventRequestDate = new DateTime(),
                    Event = _iEventRepository.getEvent(eventRequestModel.requestedEventId),
                    eventRequesterId = userRecord.id
                };
                
            }
            return View(eventRequestModel);
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

        [HttpGet("event/all")]
        public JsonResult getAllEvents()
        {
            IEnumerable<Event> allevnts = _iEventRepository.allEvents();
            return new JsonResult(allevnts);
        }
    }
}
