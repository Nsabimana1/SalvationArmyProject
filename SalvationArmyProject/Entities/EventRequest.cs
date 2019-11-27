using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class EventRequest
    {
        public Guid eventRequestId { get; set; }
        public DateTime eventRequestDate { get; set; }
        public string eventName { get; set; }
        public string  eventDescription { get; set; }
    }
}
