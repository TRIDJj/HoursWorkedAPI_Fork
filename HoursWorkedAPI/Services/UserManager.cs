using System;
using System.Collections.Generic;
using AutoMapper;
using HoursWorkedAPI.Interfaces;
using HoursWorkedAPI.Models;
using HoursWorkedAPI.Repositories;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.Services
{
    public class UserManager : IUserManager
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Create(UserViewModel userView)
        {
            try
            {
                var newUser = _mapper.Map<UserModel>(userView);
                _userRepository.Create(newUser);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<UserViewModel> GetList()
        {
            var userList = _mapper.Map<IEnumerable<UserModel>,List<UserViewModel>>(_userRepository.GetAll());
            return userList;
        }

        public void Delete(Guid id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(UserViewModel userView)
        {
            try
            {
                var changeableUser = _mapper.Map<UserModel>(userView);
                _userRepository.Update(changeableUser);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}