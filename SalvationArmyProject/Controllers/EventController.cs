using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private IEventResponseRepository _iEventResponseRepository;

        public EventController(IEventRepository iEventRepository, IUserInfoRepository iUserInfoRepository,
            IFeedbackRepository iFeedbackRepository, IEventRequestRepository iEventRequestRepository,
            IEventResponseRepository iEventResponseRepository) {
            _iEventRepository = iEventRepository;
            _iUserInfoRepository = iUserInfoRepository;
            _iEventRequestRepository = iEventRequestRepository;
            _iFeedbackRepository = iFeedbackRepository;
            _iEventResponseRepository = iEventResponseRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult EventRequest(string id)
        {
            Event ev = _iEventRepository.getEvent(new Guid(id));
            TempData["EventId"] = ev.eventId;
            TempData["EventName"] = ev.eventName;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult EventRequest(EventRequestViewModel eventRequestModel)
        {
            if (ModelState.IsValid) {
                //string curUserEmail = ;
                User userRecord = _iUserInfoRepository.getUserByEmail(eventRequestModel.email);
                userRecord.firstName = eventRequestModel.firstName;
                userRecord.lastName = eventRequestModel.lastName;
                userRecord.phoneNumber = eventRequestModel.phoneNumber;
                _iUserInfoRepository.SaveAllNewChanges();
                Event requestedEvent = _iEventRepository.getEvent(eventRequestModel.requestedEventId);
               
                EventRequest eventRequest = new EventRequest()
                {
                    eventRequestId = new Guid(),
                    eventFK = eventRequestModel.requestedEventId,
                    eventDescription = "",
                    eventRequestDate = new DateTime(),
                    Event = requestedEvent,
                    eventRequesterId = userRecord.id
                };

                if (requestedEvent.eventRequests == null) {
                    requestedEvent.eventRequests = new LinkedList<EventRequest>();
                }
                requestedEvent.eventRequests.Add(eventRequest);
                _iEventRequestRepository.addEventRequest(eventRequest);
                _iEventRequestRepository.saveAllChanges();
                _iEventRepository.saveAllChanges();
                return RedirectToAction("index", "home");

                // do the chech whether the user is alread requested
            }
            return View(eventRequestModel);
        }


        [HttpGet]
        [Authorize]
        public IActionResult EventAddition()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

        [HttpPost("/event/response")]
        public IActionResult Respond([FromBody]EventResponseViewModel eventResponseView)
        {
            if (eventResponseView == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (ModelState.IsValid)
            {
                EventResponse eventResponse = new EventResponse()
                {
                    eventResponseId = new Guid(),
                    eventRequestFK = eventResponseView.eventRequestFK,
                    eventResponseComent = eventResponseView.eventResponseComment,
                    eventResponseTime = new DateTime(),
                    responseStatus = eventResponseView.responseStatus

                };

                EventRequest requestedEventTobeReponded = _iEventRequestRepository.getEventRequest(eventResponseView.eventRequestFK);
                requestedEventTobeReponded.eventReponse = eventResponse;
                _iEventResponseRepository.addEventResponse(eventResponse);
                _iEventRequestRepository.updateEventRequest(requestedEventTobeReponded);
            }
            else {
                throw new System.ArgumentException("Parameter cannot be null", "original"); 
            }
            return Ok(true);
        }
        
        [HttpGet("/event/userApprovedEvents/{email}")]
        public IActionResult GetUserUpprovedEventByEmail(string email) {
            var user = _iUserInfoRepository.getUserByEmail(email);
            var approvedUsers = _iEventRepository.GetUserUpprovedEventById(user.id);
            return new JsonResult(approvedUsers);
        }

        [HttpGet("/event/eventrequests/{eventId}")]
        public IActionResult GetEventRequestByEventId(string eventId)
        {
            var eventreqests = _iEventRequestRepository.getEventReuqestByEventFK(new Guid(eventId));
            return new JsonResult(eventreqests);
        }


        [HttpPost("/event/feedbackPost")]
        public IActionResult FeedbackPost([FromBody]FeedbackViewModel feedback)
        {
            if (feedback == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            if (ModelState.IsValid)
            {
                var feedbackN = new Feedback()
                {
                    feedbackId = new Guid(),
                    feedbackContent = feedback.feedbackContent,
                    eventFK = feedback.eventID,
                    userFK = _iUserInfoRepository.getUserByEmail(feedback.emailId).id,
                    Event = _iEventRepository.getEvent(feedback.eventID),
                    User = _iUserInfoRepository.getUserByEmail(feedback.emailId)
                };
                this._iFeedbackRepository.addFeedback(feedbackN);
                return RedirectToAction("myEvents", "Event");
            }
            return View(feedback);
        }
    }
}
