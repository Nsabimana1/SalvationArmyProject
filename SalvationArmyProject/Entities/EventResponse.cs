using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class EventResponse
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid eventResponseId { get; set; }
        public DateTime eventResponseTime { get; set; }
        public bool responseStatus { get; set; }
        public string eventResponseComent { get; set; }
        [ForeignKey("eventRequestFK")]
        public Event EventRequest { get; set; }
        public Guid eventRequestFK { get; set; }
    }
}
