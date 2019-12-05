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
        private IFeedbackRepository _iFeedbackRepository;
        private IEventRequestRepository _iEventRequestRepository;

        public EventController(IEventRepository iEventRepository, IUserInfoRepository iUserInfoRepository,
            IFeedbackRepository iFeedbackRepository) {
            _iEventRepository = iEventRepository;
            _iUserInfoRepository = iUserInfoRepository;
            _iEventRequestRepository = iEventRequestRepository;
            _iFeedbackRepository = iFeedbackRepository;
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
                _iEventRequestRepository.addEventRequest(eventRequest);
                return RedirectToAction("index", "home");


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

        [HttpGet("eventRequest/all")]
        public JsonResult getAllEventRequests()
        {
            IEnumerable<EventRequest> alleveRequests = _iEventRequestRepository.allEventRequests();
            return new JsonResult(alleveRequests);
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback(FeedbackViewModel feedback)
        {
            if (ModelState.IsValid)
            {
                var feedbackN = new Feedback()
                {
                    feedbackId = new Guid(),
                    feedbackContent = feedback.feedbackContent,
                    eventFK = feedback.eventID,
                    userFK = feedback.userID,
                    Event = _iEventRepository.getEvent(feedback.eventID),
                    User = _iUserInfoRepository.getUser(feedback.userID)
                };
                this._iFeedbackRepository.addFeedback(feedbackN);
                return RedirectToAction("feedback", "home");
            }
            return View(feedback);
        }

        [HttpGet]
        public IActionResult MyEvents()
        {
            return View();
        }
    }
}
