using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.ViewModels
{
    public class ProfileViewModelReturn
    {
        public User currentUser { get; set; } 
        public IEnumerable<EventResponse> userResponces { get; set; }
        public UserProfileViewModel profileViewModel { get; set; }
    }
}
