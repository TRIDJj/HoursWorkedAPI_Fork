using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HoursWorkedAPI.DTO.Requests;
using HoursWorkedAPI.DTO.Responses;
using HoursWorkedAPI.Interfaces;

namespace HoursWorkedAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/api/users")]
        public Task<UserGetResponse> Get()
        {
            return Task.Run(() =>
            {
                var response = new UserGetResponse();
                response.Users = _userManager.GetList();

                return response;
            });
        }

        [HttpPost]
        [Route("/api/users")]
        public Task<BaseResponse> Create(UserCreateRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();
                _userManager.Create(request.User);

                return response;
            });
        }

        [HttpDelete]
        [Route("/api/users/{id}")]
        public Task<BaseResponse> Delete(UserDeleteRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();
                _userManager.Delete(request.Id);

                return response;
            });
        }

        [HttpPut]
        [Route("/api/users/{id}")]
        public Task<BaseResponse> Update(UserUpdateRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();
                _userManager.Update(request.User);

                return response;
            });
        }
    }
}