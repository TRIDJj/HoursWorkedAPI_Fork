using System;
using Microsoft.AspNetCore.Mvc;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportGetRequest
    {
        [FromRoute(Name = "user-id")] 
        public Guid UserId { get; set; }
        [FromQuery(Name = "date-begin")] 
        public DateTime DateBegin { get; set; }
        [FromQuery(Name = "date-end")] 
        public DateTime DateEnd { get; set; }
    }
}