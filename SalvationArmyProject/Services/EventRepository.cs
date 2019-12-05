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
