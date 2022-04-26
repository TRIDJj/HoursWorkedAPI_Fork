using System;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.DTO.Requests
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; } 
        public UserViewModel User { get; set; }
    }
}