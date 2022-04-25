using HoursWorkedAPI.Models;
using System;
using System.Collections.Generic;

namespace HoursWorkedAPI.Repository.Interfaces
{
    public interface IWorkReportRepository
    {
        string Create(WorkReport work);
        string Update(WorkReport work);
        string Delete(Guid id);
        List<WorkReport> Get( Guid userId, DateTime dateBegin, DateTime dateEnd);
    }
}
