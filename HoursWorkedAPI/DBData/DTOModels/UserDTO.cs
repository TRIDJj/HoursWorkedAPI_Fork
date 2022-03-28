using System;
using System.ComponentModel.DataAnnotations;

namespace HoursWorkedAPI.DBData.DTOModels
{

    public class UserDTO
    {
        [Required]
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
    }
}
