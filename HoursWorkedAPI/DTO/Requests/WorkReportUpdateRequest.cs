using System;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportUpdateRequest
    {
        public Guid UserId { get; set; } 
        public Guid ReportId { get; set; }
        public WorkReportModel WorkReport { get; set; }
    }
}