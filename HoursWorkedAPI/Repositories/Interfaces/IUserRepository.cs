using System;
using System.Collections.Generic;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        string Create(UserModel user);
        string Update(UserModel user);
        string Delete(Guid id);
        List<UserModel> Get();
    }
}
