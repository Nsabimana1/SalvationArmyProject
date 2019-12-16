﻿using System;
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

        public IEnumerable<EventRequest> getEventReuqestByEventFK(Guid evFK) {
             return this._dbContext.EventRequests.Where(e => e.eventFK == evFK).ToList();
        }

        public bool eventRequestExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public EventRequest getEventRequest(Guid id)
        {
            return _dbContext.EventRequests.Where(e=> e.eventRequestId == id).FirstOrDefault();
        }

        public void removeEventRequest(Guid id)
        {
            EventRequest ev = _dbContext.EventRequests.FirstOrDefault(e => e.eventRequestId == id);
            _dbContext.EventRequests.Remove(ev);
        }

        public void saveAllChanges()
        {
            _dbContext.SaveChanges();
        }

        public void updateEventRequest(EventRequest eventRequest)
        {
            var evenReq = _dbContext.EventRequests.Where(e => e.eventRequestId == eventRequest.eventRequestId).FirstOrDefault();
            evenReq.eventRequesterId = eventRequest.eventRequesterId;
            evenReq.eventRequestDate = eventRequest.eventRequestDate;
            evenReq.eventReponse = eventRequest.eventReponse;
            evenReq.eventDescription = eventRequest.eventDescription;
            evenReq.eventFK = eventRequest.eventFK;
            evenReq.Event = eventRequest.Event;
            _dbContext.SaveChanges();
        }
    }
}
