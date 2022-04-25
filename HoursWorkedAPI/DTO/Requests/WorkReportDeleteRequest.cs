using System;
using Microsoft.AspNetCore.Mvc;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportDeleteRequest
    {
        [FromRoute(Name = "user-id")] 
        public Guid UserId { get; set; }

        [FromRoute(Name = "report-id")]
        public Guid ReportId { get; set; }
    }
}