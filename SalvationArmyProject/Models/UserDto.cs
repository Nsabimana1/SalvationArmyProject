using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Models
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string userPrivilage { get; set; }
    }
}
