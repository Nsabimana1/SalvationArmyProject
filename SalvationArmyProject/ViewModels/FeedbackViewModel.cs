using System;
using System.ComponentModel.DataAnnotations;

namespace SalvationArmyProject.ViewModels
{
    public class FeedbackViewModel
    {
        [Required]
        [Display(Name = "Feedback")]
        public string feedbackContent { get; set; }

        [Required]
        public Guid eventID { get; set; }

        [Required]
        public string emailId { get; set; }
    }
}

