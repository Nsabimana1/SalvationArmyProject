using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public interface IEventRepository
    {
        bool eventExists(Guid id);
        Event getEvent(Guid id);
        DateTime getDateTime(Guid id);
        string getEventName(Guid id);
        string getDescription(Guid id);
        void addEvent(Event e);
        void removeEvent(Guid id);
        void updateEvent(Event e);
        IEnumerable<Event> allEvents();
    }
}
