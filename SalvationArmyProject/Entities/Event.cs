using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class Event
    {
        [Key]
        public Guid eventId { get; set; }
        public DateTime eventDateTime { get; set; }
        public string  eventName { get; set; }
        public string eventDescription { get; set; }
        public ICollection<EventRequest> Books { get; set; }
    }
}
