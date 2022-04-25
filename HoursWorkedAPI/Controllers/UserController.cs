using HoursWorkedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HoursWorkedAPI.DTO.Requests;
using HoursWorkedAPI.DTO.Responses;
using HoursWorkedAPI.Repositories.Interfaces;

namespace HoursWorkedAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>
        /// JSON формата:
        /// "result": [
        /// {
        ///     "email": email,
        ///     "lastName": Фамилия,
        ///     "firstName": Имя,
        ///     "middleName": Отчество
        /// },
        /// ],
        /// "resultCode": 200
        /// }
        /// Или сообщение об ошибке.
        /// </returns>
        [HttpGet]
        [Route("/api/users")]
        public ActionResult<BaseResponse> Get()
        {
            try
            {
                var result = _userRepository.Get();
                if (result.Count == 0)
                {
                    return ResultResponse<string>.GetEmptyResultResponse("Не найдены значения в базе");
                }
                else
                {
                    return ResultResponse<List<UserModel>>.GetSuccessResponse(result);
                }
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetErrorResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="user">
        /// JSON формата:
        /// { 
        /// "Email": "mail@mail.ru", 
        /// "LastName": "Фамилия", 
        /// "FirstName": "Имя", 
        /// "MiddleName": "Отчество"
        /// }
        /// "Email", "LastName", "FirstName" обязательны.
        /// </param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpPost]
        [Route("/api/users")]
        public ActionResult<BaseResponse> Create(UserCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.User.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передан пустой Email");
            }
            if (!new EmailAddressAttribute().IsValid(request.User.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Не верный формат Email");
            }
            if (string.IsNullOrEmpty(request.User.LastName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передана пустая Фамилия");
            }
            if (string.IsNullOrEmpty(request.User.FirstName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передано пустое Имя");
            }
            try
            {
                var result = _userRepository.Create(request.User);

                if (result.Contains("Ошибка:"))
                { 
                    return ResultResponse<string>.GetErrorResultResponse(result);
                }
                return ResultResponse<string>.GetSuccessResponse(result);
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpDelete]
        [Route("/api/users/{id}")]
        public ActionResult<BaseResponse> Delete(UserDeleteRequest request)
        {
            if (request.Id == null)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой id");
            }
            try
            {
                 var result = _userRepository.Delete(request.Id);
                 if (result.Contains("Ошибка:"))
                 {
                     return ResultResponse<string>.GetErrorResultResponse(result);
                 }
                 return ResultResponse<string>.GetSuccessResponse(result );
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Изменение пользователя.
        /// </summary>
        /// <param name="user">/// JSON формата:
        /// { 
        /// "UserId": "c1e7a097-4529-487e-900e-c468f89f60b5",
        /// "Email": "mail@mail.ru", 
        /// "LastName": "Фамилия", 
        /// "FirstName": "Имя", 
        /// "MiddleName": "Отчество"
        /// }
        /// "UserId", "Email", "LastName", "FirstName" обязательны.</param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpPut]
        [Route("/api/users/{id}")]
        public ActionResult<BaseResponse> Update(UserUpdateRequest request)
        {
            if (request.Id == Guid.Empty)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой id пользователя");
            }
            if (string.IsNullOrEmpty(request.User.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой Email");
            }
            if(!new EmailAddressAttribute().IsValid(request.User.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Не верный формат Email");
            }
            if (string.IsNullOrEmpty(request.User.LastName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передана пустая Фамилия");
            }
            if (string.IsNullOrEmpty(request.User.FirstName))
            {
               return ResultResponse<string>.GetEmptyResultResponse("Передано пустое Имя");
            }
            try
            {
                request.User.UserId = request.Id;
                var result = _userRepository.Update(request.User);
                  
                if (result.Contains("Ошибка:"))
                {
                    return ResultResponse<string>.GetErrorResultResponse(result);
                }
                return ResultResponse<string>.GetSuccessResponse(result);
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }
    }
}