using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursWorkedAPI.Models
{
    public class MainResponse
    {
        public ResultOperation ResultCode { get; set; }
    }

    public class ResultResponse<T> : MainResponse
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
