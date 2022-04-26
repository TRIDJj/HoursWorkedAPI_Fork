using System;
using System.Collections.Generic;
using AutoMapper;
using HoursWorkedAPI.Interfaces;
using HoursWorkedAPI.Models;
using HoursWorkedAPI.Repositories;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.Services
{
    public class WorkReportManager : IWorkReportManager
    {
        private readonly WorkReportRepository _workReportRepository;
        private readonly IMapper _mapper;

        public WorkReportManager(WorkReportRepository workReportRepository, IMapper mapper)
        {
            _workReportRepository = workReportRepository;
            _mapper = mapper;
        }

        public void Create(WorkReportViewModel workReportView)
        {
            try
            {
                var newWork = _mapper.Map<WorkReportModel>(workReportView);
                _workReportRepository.Create(newWork);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _workReportRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<WorkReportViewModel> Get(Guid id, DateTime dateBegin, DateTime dateEnd)
        {
            var workReportList = _mapper.Map<List<WorkReportViewModel>>(_workReportRepository.GetList(id, dateBegin, dateEnd));
            return workReportList;
        }

        public void Update(WorkReportViewModel workReportView)
        {
            var changeableWorkReport = _mapper.Map<WorkReportModel>(workReportView);
            _workReportRepository.Update(changeableWorkReport);
        }
    }
}