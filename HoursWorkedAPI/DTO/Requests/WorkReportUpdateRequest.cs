using System;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.DTO.Requests
{
    public class WorkReportUpdateRequest
    {
        public Guid UserId { get; set; } 
        public Guid ReportId { get; set; }
        public WorkReportViewModel WorkReport { get; set; }
    }
}