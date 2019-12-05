using System;
using System.ComponentModel.DataAnnotations;

namespace SalvationArmyProject.ViewModels
{
    public class FeedbackViewModel
    {
        [Required]
        [Display(Name = "Feedback")]
        public string feedbackContent { get; set; }

    }
}

