using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.ViewModels
{
    public class EventRequestViewModel
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string birthDate { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string eventName { get; set; }
    }
}
