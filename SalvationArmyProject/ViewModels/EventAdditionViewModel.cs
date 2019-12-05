using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.ViewModels
{
    public class EventAdditionViewModel
    {
        [Required]
        public string eventName { get; set; }
        [Required]
        public int eventDuration { get; set; }
        [Required]
        public DateTime eventDateTime { get; set; }
        [Required]
        public string eventDescription { get; set; }
    }
}
