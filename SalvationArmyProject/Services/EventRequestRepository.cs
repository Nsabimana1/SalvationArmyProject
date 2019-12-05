using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public class EventRequestRepository : IEventRequestRepository
    {
        private DBcontext _dbContext;
        public EventRequestRepository(DBcontext dBcontext) {
            this._dbContext = dBcontext;
        }
        public void addEventRequest(EventRequest e)
        {
            this._dbContext.EventRequests.Add(e);
            this._dbContext.SaveChanges();

        }

        public IEnumerable<EventRequest> allEventRequests()
        {
            return this._dbContext.EventRequests;
        }

        public bool eventRequestExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public EventRequest getEventRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public void removeEventRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveAllChanges()
        {
            _dbContext.SaveChanges();
        }

        public void updateEventRequest(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
