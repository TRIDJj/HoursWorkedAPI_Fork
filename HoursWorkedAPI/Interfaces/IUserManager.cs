using System;
using System.Collections.Generic;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.Interfaces
{
    public interface IUserManager
    {
        void Create(UserViewModel userView);
        List<UserViewModel> GetList();
        void Delete(Guid id);
        void Update(UserViewModel userView);
    }
}