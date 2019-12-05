using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public interface IEventRequestRepository
    {
        bool eventRequestExists(Guid id);
        EventRequest getEventRequest(Guid id);
        void addEventRequest(EventRequest e);
        void removeEventRequest(Guid id);
        void updateEventRequest(Event e);
        IEnumerable<EventRequest> allEventRequests();
        void saveAllChanges();
    }
}
