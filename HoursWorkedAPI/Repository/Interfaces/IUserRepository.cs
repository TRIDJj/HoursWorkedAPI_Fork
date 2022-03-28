using HoursWorkedAPI.Models;
using System;
using System.Collections.Generic;

namespace HoursWorkedAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        string Create(User user);
        string Update(User user);
        string Delete(Guid id);
        List<User> Get();
    }
}
