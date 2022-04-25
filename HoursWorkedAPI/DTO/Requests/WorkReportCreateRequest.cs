using System;
using HoursWorkedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportCreateRequest
    {
        [FromRoute(Name = "user-id")]
        public Guid UserId { get; set; }
        public WorkReportModel WorkReport { get; set; }
    }
}