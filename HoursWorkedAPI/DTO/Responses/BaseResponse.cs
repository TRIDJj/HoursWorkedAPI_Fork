using HoursWorkedAPI.Enums;

namespace HoursWorkedAPI.DTO.Responses
{
    public class BaseResponse
    {
        public ResultOperation ResultCode { get; set; }
        public string FailMessage { get; set; }

        public BaseResponse()
        {
            ResultCode = ResultOperation.OK;
            FailMessage = string.Empty;
        }
    }
}