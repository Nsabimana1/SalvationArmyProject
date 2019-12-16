using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public interface IEventResponseRepository
    {
        bool eventResponseExists(Guid id);
        EventResponse getEventResponse(Guid id);
        void addEventResponse(EventResponse e);
        void removeEventResponse(Guid id);
        void updateEventResponse(EventResponse e);
        IEnumerable<EventResponse> allEventResponses();
        void saveAllChanges();
    }
}
