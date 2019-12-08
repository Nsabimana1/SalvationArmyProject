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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid eventId { get; set; }
        public DateTime eventDateTime { get; set; }
        public string  eventName { get; set; }
        public int eventDuration { get; set; }
        public string eventDescription { get; set; }
        public ICollection<EventRequest> eventRequests { get; set; }

        //[ForeignKey("feedbackFK")]
        //public string feedbackFK { get; set; }
        //public Feedback feedback { get; set; }
    }
}
