using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class EventRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid eventRequestId { get; set; }
        public DateTime eventRequestDate { get; set; }
        public Guid eventRequesterId { get; set; }
        public string eventDescription { get; set; }
        [ForeignKey("eventFK")]
        public Event Event { get; set; }
        public Guid eventFK { get; set; }
        public EventResponse eventReponse { get; set; }
    }
}
