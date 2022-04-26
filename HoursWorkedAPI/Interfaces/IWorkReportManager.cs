using System;
using System.Collections.Generic;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.Interfaces
{
    public interface IWorkReportManager
    {
        void Create(WorkReportViewModel workReportView);
        void Delete(Guid id);
        List<WorkReportViewModel> Get(Guid id, DateTime dateBegin, DateTime dateEnd);
        void Update(WorkReportViewModel workReportView);
    }
}