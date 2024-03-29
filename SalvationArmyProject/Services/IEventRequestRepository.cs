﻿using System;
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
        IEnumerable<EventRequest> getEventReuqestByEventFK(Guid evFK);
        void addEventRequest(EventRequest e);
        void removeEventRequest(Guid id);
        void updateEventRequest(EventRequest e);
        IEnumerable<EventRequest> allEventRequests();
        IEnumerable<EventResponse> getRequestResponsesByUser(Guid id);
        void saveAllChanges();

    }
}
