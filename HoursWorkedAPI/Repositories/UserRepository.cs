using System;
using System.Collections.Generic;
using System.Linq;
using HoursWorkedAPI.DBData.Database;
using HoursWorkedAPI.Helpers;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(UserModel user)
        {
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new DataException($"Ошибка: Email {user.Email} уже зарегестрирован");
            }

            _context.Users.Add(user);
            Save();
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new NotFoundException($"Ошибка удаления: Пользователь с guid {id} отсутствует");
            }

            _context.Users.Remove(user);
            Save();
        }

        public List<UserModel> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(UserModel user)
        {
            if (_context.Users.Any(x => x.Email == user.Email && x.UserId != user.UserId))
            {
                throw new DataException($"Ошибка: Email {user.Email} уже зарегестрирован");
            }
            _context.Users.Update(user);
            Save();
        }
    }
}