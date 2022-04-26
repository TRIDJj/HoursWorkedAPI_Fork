using System.Collections.Generic;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.DTO.Responses
{
    public class UserGetResponse : BaseResponse
    {
        public List<UserViewModel> Users { get; set; }
    }
}