using System;
using HoursWorkedAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportCreateRequest
    {
        [FromRoute(Name = "user-id")]
        public Guid UserId { get; set; }
        public WorkReportViewModel WorkReport { get; set; }
    }
}