using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class Event
    {
        public Guid eventId { get; set; }
        [ForeignKey("eventFK")]
        public ICollection<EventRequest> Books { get; set; }
    }
}
