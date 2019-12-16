using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public class EventRepositry : IEventRepository
    {
        DBcontext _dBcontext;
        public EventRepositry(DBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public void addEvent(Event e)
        {
            _dBcontext.Events.Add(e);
            _dBcontext.SaveChanges();
        }

        public IEnumerable<Event> allEvents()
        {
            return _dBcontext.Events;
        }

        public bool eventExists(Guid id)
        {
            var user = _dBcontext.Events.FirstOrDefault(u => u.eventId == id);
            return user != null;
        }

        public DateTime getDateTime(Guid id)
        {
            var dateTime = _dBcontext.Events.FirstOrDefault(u => u.eventId == id);
            return dateTime.eventDateTime;
        }

        public string getDescription(Guid id)
        {
            throw new NotImplementedException();
        }

        public Event getEvent(Guid id)
        {
            return _dBcontext.Events.FirstOrDefault(e => e.eventId == id);
        }

        public string getEventName(Guid id)
        {
            var e = _dBcontext.Events.FirstOrDefault(u => u.eventId == id);
            return e.eventName;
        }

        public IEnumerable<Event> GetUserUpprovedEventById(Guid id)
        {
            var allprovedusers = _dBcontext.EventResponses.Where(r => r.responseStatus == true).ToList();
            List<Event> events = new List<Event>();
            foreach (var res in allprovedusers) {
               Guid data = _dBcontext.EventRequests.Where(e => e.eventRequesterId == id && e.eventRequestId == res.eventRequestFK).Select(s =>s.eventFK).FirstOrDefault();
                if (data != null) {
                    events.Add(this.getEvent(data));
                }
            }
            return events;
            //var query = _dBcontext.EventResponses
            //    .Join(
            //    _dBcontext.EventRequests,
            //    EventResponse => EventResponse.eventRequestFK,
            //    EventRequest => EventRequest.eventRequestId,
            //    (EventResponse, EventRequest) => (EventResponse.responseStatus == true && EventRequest.eventRequesterId == id)
            //    ).ToList();

            //return null;
            //return (Event) query;

            //var resp = _dBcontext.EventResponses.Where(r => r.responseStatus == true)
            //    .Join(
            //    _dBcontext.EventRequests
            //    .Where(e => e.eventRequesterId == id));
            
        }

        //public Feedback getFeedback(Guid feedback)
        //{
        //    var f = _dBcontext.Feedbacks.Find(feedback);
        //    if (f != null)
        //    {
        //        return f;
        //    }
        //    return null;
        //}

        public void removeEvent(Guid id)
        {
            var ev = this.getEvent(id);
            _dBcontext.Events.Remove(ev);
        }

        public void saveAllChanges()
        {
            _dBcontext.SaveChanges();
            
        }
        public void updateEvent(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
