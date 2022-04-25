using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HoursWorkedAPI.Models
{   
    public class UserModel
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
    }
}
