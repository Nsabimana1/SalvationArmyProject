using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public class EventResponseRepository : IEventResponseRepository
    {
        private DBcontext _dBContext;
        public EventResponseRepository(DBcontext dBcontext) {
            this._dBContext = dBcontext;
        }
        public void addEventResponse(EventResponse e)
        {
            _dBContext.EventResponses.Add(e);
            _dBContext.SaveChanges();
        }

        public IEnumerable<EventResponse> allEventResponses()
        {
           return _dBContext.EventResponses;
        }

        public bool eventResponseExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public EventResponse getEventResponse(Guid id)
        {
            throw new NotImplementedException();
        }

        public void removeEventResponse(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveAllChanges()
        {
            _dBContext.SaveChanges();
        }

        public void updateEventResponse(EventResponse e)
        {
            throw new NotImplementedException();
        }
    }
}
