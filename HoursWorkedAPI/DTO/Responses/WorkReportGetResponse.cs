using System.Collections.Generic;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.DTO.Responses
{
    public class WorkReportGetResponse : BaseResponse
    {
        public List<WorkReportViewModel> WorkReports { get; set; }
    }
}