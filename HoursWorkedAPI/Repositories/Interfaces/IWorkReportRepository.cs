using System;
using System.Collections.Generic;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repositories.Interfaces
{
    public interface IWorkReportRepository
    {
        string Create(WorkReportModel work);
        string Update(WorkReportModel work);
        string Delete(Guid id);
        List<WorkReportModel> Get( Guid userId, DateTime dateBegin, DateTime dateEnd);
    }
}
