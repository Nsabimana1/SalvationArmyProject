using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.ViewModels
{
    public class EventResponseViewModel
    {
        public DateTime eventResponseTime { get; set; }
        [Required]
        public bool responseStatus { get; set; }
        public string eventResponseComent { get; set; }
        [Required]
        public Guid eventRequestFK { get; set; }
    }
}
