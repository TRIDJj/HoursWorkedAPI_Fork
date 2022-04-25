using HoursWorkedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HoursWorkedAPI.DTO.Requests;
using HoursWorkedAPI.DTO.Responses;
using HoursWorkedAPI.Repositories.Interfaces;

namespace HoursWorkedAPI.Controllers
{
    [ApiController]
    public class WorkReportController : Controller
    {
        private readonly IWorkReportRepository _workReportRepository;

        public WorkReportController(IWorkReportRepository workReportRepository)
        {
            _workReportRepository = workReportRepository;
        }

        /// <summary>
        /// Получение записей по id пользователя и дате.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="date">Дата.</param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": [
        /// {
        ///     "id": "b1e25823-1237-4b7f-b044-d58dad94f431",
        ///     "userId": "5b229cd5-310c-4bd6-b2c5-bda25599040f",
        ///     "note": "Примечание",
        ///     "numberOfHours": Количество часов,
        ///     "date": "2022-01-01T00:00:00"
        /// }
        /// ],
        /// "resultCode": 200
        /// }
        /// Или сообщение об ошибке
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpGet]
        [Route("/api/users/{user-id}/work-reports")]
        public ActionResult<BaseResponse> Get(WorkReportGetRequest request)
        {
            try
            {
                var result = _workReportRepository.Get(request.UserId, request.DateBegin, request.DateEnd);
                if (result.Count == 0)
                {
                    return ResultResponse<string>.GetEmptyResultResponse("Не найдены значения в базе");
                }
                else
                {
                    return ResultResponse<List<WorkReportModel>>.GetSuccessResponse(result);
                }
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Создание отчета о работе.
        /// </summary>
        /// <param name="workReport">
        /// JSON формата:
        /// { 
        ///     "UserId": "5b229cd5-310c-4bd6-b2c5-bda25599040f", 
        ///     "Note": "Примечание", 
        ///     "NumberOfHours": Количество часов, 
        ///     "Date": "2022-01-01"
        /// }
        /// </param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpPost]
        [Route("/api/users/{user-id}/work-reports")]
        public ActionResult<BaseResponse> Create(WorkReportCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.WorkReport.Note))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передано пустое примечание");
            }
            if (request.WorkReport.NumberOfHours == 0)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Кол-во часов должн быть > 0");
            }
            try
            {
                request.WorkReport.UserId = request.UserId;
                var result = _workReportRepository.Create(request.WorkReport);

                if (result.Contains("Ошибка:"))
                {
                    return ResultResponse<string>.GetErrorResultResponse(result);
                }
                return ResultResponse<string>.GetSuccessResponse(result);
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Удаление отчета о работе.
        /// </summary>
        /// <param name="id">Идентификатор отчета о работе.</param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpDelete]
        [Route("/api/users/{user-id}/work-reports/{report-id}")]
        public ActionResult<BaseResponse> Delete(WorkReportDeleteRequest request)
        {
            if (request.ReportId == Guid.Empty)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передан пустой id");
            }
            try
            {
                var result = _workReportRepository.Delete(request.ReportId);
                if (result.Contains("Ошибка:"))
                {
                    return ResultResponse<string>.GetErrorResultResponse(result);
                }
                return ResultResponse<string>.GetSuccessResponse(result);
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }

        /// <summary>
        /// Изменение отчета о работе.
        /// </summary>
        /// <param name="workReport">
        /// JSON формата:
        /// { 
        ///     "Id": "d724417b-40e1-430f-a779-d88da75a705d",
        ///     "UserId": "5b229cd5-310c-4bd6-b2c5-bda25599040f", 
        ///     "Note": "Примечание", 
        ///     "NumberOfHours": Количество часов работы, 
        ///     "Date": "2022-01-01"
        /// }
        /// </param>
        /// <returns>
        /// JSON формата:
        /// {
        /// "result": Сообшение,
        /// "resultCode": Код сообщения
        /// }
        /// </returns>
        [HttpPut]
        [Route("/api/users/{userId}/work-reports/{reportId}")]
        public ActionResult<BaseResponse> Update(WorkReportUpdateRequest request)
        {
            if (string.IsNullOrEmpty(request.WorkReport.Note))
            {
                return ResultResponse<string>.GetEmptyResultResponse("Передано пустое примечание");
            }
            if (request.WorkReport.NumberOfHours == 0)
            {
                return ResultResponse<string>.GetEmptyResultResponse("Кол-во часов должн быть > 0");
            }
            try
            {
                request.WorkReport.Id = request.ReportId;
                request.WorkReport.UserId = request.UserId;
                var result = _workReportRepository.Update(request.WorkReport);

                if (result.Contains("Ошибка:"))
                {
                    return ResultResponse<string>.GetErrorResultResponse(result);
                }
                return ResultResponse<string>.GetSuccessResponse(result);
            }
            catch (Exception e)
            {
                return ResultResponse<string>.GetEmptyResultResponse(e.Message);
            }
        }
    }
}