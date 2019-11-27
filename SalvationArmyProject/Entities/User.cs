using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalvationArmyProject.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string  lastName { get; set; }
        public string  email { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string userPrivilage { get; set; }
    }


}
