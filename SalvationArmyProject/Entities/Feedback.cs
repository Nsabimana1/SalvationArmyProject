using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class Feedback
    {
        [Key]
        public Guid feedbackId { get; set; }

        public string feedbackContent { get; set; }

        [ForeignKey("userFK")]
        public int userFK { get; set; }
        public User user { get; set; }
        
        [ForeignKey("eventFK")]
        public int eventFK { get; set; }
        public Event events { get; set; }
    }
}
