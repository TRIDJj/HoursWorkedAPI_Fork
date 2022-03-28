using HoursWorkedAPI.Models;
using HoursWorkedAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoursWorkedAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
        [Route("/api/users/getall")]
        public ActionResult<MainResponse> Get()
        {
            try
            {
                var result = userRepository.Get();
                if (result.Count == 0)
                {
                    return ResultResponse<string>.GetEmptyResultResponse("Не найдены значения в базе");
                }
                else
                {
                    return ResultResponse<List<User>>.GetSuccessResponse(result);
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
        [Route("/api/users/create")]
        public ActionResult<MainResponse> Create(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передан пустой Email");
            }
            if (!new EmailAddressAttribute().IsValid(user.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Не верный формат Email");
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передана пустая Фамилия");
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Ошибка: Передано пустое Имя");
            }
            try
            {

                var result = userRepository.Create(user);

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
       [Route("/api/users/delete/{id}")]
       public ActionResult<MainResponse> Delete(Guid id)
       {
           if (id == null)
           {
               return ResultResponse<string>.GetEmptyResultResponse("Передан пустой id");
           }
           try
           {
                var result = userRepository.Delete(id);
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
        [HttpPost]
       [Route("/api/users/update")]
       public ActionResult<MainResponse> Update(User user)
       {
            if (user.UserId == Guid.Empty)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой id пользователя");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой Email");
            }
            if(!new EmailAddressAttribute().IsValid(user.Email))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Не верный формат Email");
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передана пустая Фамилия");
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передано пустое Имя");
            }
            try
            {
                 var result = userRepository.Update(user);

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
