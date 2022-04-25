using HoursWorkedAPI.Enums;

namespace HoursWorkedAPI.DTO.Responses
{
    public class ResultResponse<T> : BaseResponse
    {
        public virtual T Result { get; set; }

        public static ResultResponse<T> GetSuccessResponse(T item)
        {
            return new ResultResponse<T>
            {
                Result = item,
                ResultCode = ResultOperation.OK
            };
        }

        public static ResultResponse<T> GetEmptyResultResponse(T item)
        {
            return new ResultResponse<T>
            {
                Result = item,
                ResultCode = ResultOperation.NotFound
            };
        }

        public static ResultResponse<T> GetErrorResultResponse(T item)
        {
            return new ResultResponse<T>
            {
                Result = item,
                ResultCode = ResultOperation.DataError
            };
        }
    }
}