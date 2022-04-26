using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HoursWorkedAPI.DTO.Responses;
using HoursWorkedAPI.Enums;
using HoursWorkedAPI.Helpers;
using Microsoft.AspNetCore.Http;

namespace HoursWorkedAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = new BaseResponse();

                switch (error)
                {
                    case DataException e:
                        response.ResultCode = ResultOperation.DataError;
                        response.FailMessage = error.Message;
                        break;
                    case NotFoundException e:
                        response.ResultCode = ResultOperation.NotFound;
                        response.FailMessage = error.Message;
                        break;
                    default:
                        response.ResultCode = ResultOperation.NotFound;
                        response.FailMessage = error.Message;
                        break;
                }

                var responseSerialized = JsonSerializer.Serialize(response);
                var responseBytes = Encoding.UTF8.GetBytes(responseSerialized);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);
            }
        }
    }
}