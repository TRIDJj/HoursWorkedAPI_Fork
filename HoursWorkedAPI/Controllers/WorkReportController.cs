using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HoursWorkedAPI.DTO.Requests;
using HoursWorkedAPI.DTO.Responses;
using HoursWorkedAPI.Interfaces;

namespace HoursWorkedAPI.Controllers
{
    [ApiController]
    public class WorkReportController : Controller
    {
        private readonly IWorkReportManager _workReportManager;

        public WorkReportController(IWorkReportManager workReportManager)
        {
            _workReportManager = workReportManager;
        }

        [HttpGet]
        [Route("/api/users/{user-id}/work-reports")]
        public Task<WorkReportGetResponse> Get(WorkReportGetRequest request)
        {
            return Task.Run(() =>
            {
                var response = new WorkReportGetResponse();
                response.WorkReports = _workReportManager.Get(request.UserId,request.DateBegin, request.DateEnd);

                return response;
            });
        }

        [HttpPost]
        [Route("/api/users/{user-id}/work-reports")]
        public Task<BaseResponse> Create(WorkReportCreateRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();

                var newWorkReport = request.WorkReport;
                newWorkReport.UserId = request.UserId;
                _workReportManager.Create(newWorkReport);

                return response;
            });
        }

        [HttpDelete]
        [Route("/api/users/{user-id}/work-reports/{report-id}")]
        public Task<BaseResponse> Delete(WorkReportDeleteRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();

                _workReportManager.Delete(request.ReportId);

                return response;
            });
        }

        [HttpPut]
        [Route("/api/users/{userId}/work-reports/{reportId}")]
        public Task<BaseResponse> Update(WorkReportUpdateRequest request)
        {
            return Task.Run(() =>
            {
                var response = new BaseResponse();

                var updateWorkReport = request.WorkReport;
                updateWorkReport.Id = request.ReportId;
                updateWorkReport.UserId = request.UserId;

                _workReportManager.Update(request.WorkReport);

                return response;
            });
        }
    }
}