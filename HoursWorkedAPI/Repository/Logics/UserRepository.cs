using AutoMapper;
using HoursWorkedAPI.DBData.Database;
using HoursWorkedAPI.DBData.DTOModels;
using HoursWorkedAPI.Models;
using HoursWorkedAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoursWorkedAPI.Repository.Logics
{
    public class UserRepository : IUserRepository
    {
        private IMapper mapper;
        private ApplicationContext context;
        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="user">структура типа User.</param>
        /// <returns>
        /// При успешном создании записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Create(User user)
        {
            try
            {
                if (context.Users.Any(x => x.Email == user.Email))
                {
                    return $"Ошибка: Email {user.Email} уже зарегестрирован";
                }
                var newUser = mapper.Map<UserDTO>(user);
                context.Users.Add(newUser);
                context.SaveChanges();
                return $"user_guid: {newUser.UserId}";
            }
            catch(Exception e)
            {
                return $"Ошибка: {e.Message}";
            }
        }

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        /// <returns>
        /// При удалении пользователя удаляет все отчеты работе этого пользователя.
        /// При успешном удалении записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Delete(Guid id)
        {
            try
            {
                var userResult = context.Users.Single(x => x.UserId == id);
                context.Users.Remove(userResult);
                context.SaveChanges();
                return $"Данные по guid {id} удалены";
            }
            catch (Exception e)
            {
                return $"Ошибка: {e.Message}";
            }
        }

        /// <summary>
        /// Получение всех записей.
        /// </summary>
        /// <returns>
        /// Возвращает список всех пользовалетей.
        /// </returns>
        public List<User> Get()
        {
            var listUserDTO = context.Users.ToList();
            var listUser = mapper.Map<List<User>>(listUserDTO);
            return listUser;
        }

        /// <summary>
        /// Изменение пользователя.
        /// </summary>
        /// <param name="user">структура типа User.</param>
        /// <returns>
        /// При успешном создании записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Update(User user)
        {
            try
            {
                if (context.Users.Any(x => x.Email == user.Email && x.UserId != user.UserId))
                {
                    return $"Ошибка: Email {user.Email} уже зарегестрирован";
                }
                var changeableUser = mapper.Map<UserDTO>(user);
                context.Users.Update(changeableUser);
                context.SaveChanges();
                return $"user_guid: {changeableUser.UserId} изменен";
            }
            catch(Exception e)
            {
                return $"Ошибка: {e.Message}";
            }
        }
    }
}
