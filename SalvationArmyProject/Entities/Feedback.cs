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
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid feedbackId { get; set; }

        
        public string feedbackContent { get; set; }

        [ForeignKey("userFK")]
        [Required]
        public Guid userFK { get; set; }

        
        public User User { get; set; }
        
        [ForeignKey("eventFK")]
        [Required]
        public Guid eventFK { get; set; }

        public Event Event { get; set; }
    }
}
