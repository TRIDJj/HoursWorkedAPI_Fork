using System;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.DTO.Requests
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; } 
        public UserModel User { get; set; }
    }
}