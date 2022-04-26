using System;
using System.Collections.Generic;
using System.Linq;
using HoursWorkedAPI.DBData.Database;
using HoursWorkedAPI.Helpers;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repositories
{
    public class WorkReportRepository : BaseRepository
    {
        public WorkReportRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(WorkReportModel workReport)
        {
            var hours = _context.WorkReports.Where(x => x.UserId == workReport.UserId && x.Date == workReport.Date).Sum(x => x.NumberOfHours) + workReport.NumberOfHours;
            if (hours > 24)
            {
                throw new Exception($"Ошибка: Сумма времени за день не может быть больше 24 часов");
            }

            _context.WorkReports.Add(workReport);
            Save();
        }

        public void Delete(Guid id)
        {
            var workReport = _context.WorkReports.Single(x => x.Id == id);
            if (workReport == null)
            {
                throw new NotFoundException($"Ошибка удаления: WorkReport с guid {id} отсутствует");
            }
            _context.WorkReports.Remove(workReport);
            _context.SaveChanges();
        }
        
        public List<WorkReportModel> GetList(Guid id, DateTime dateBegin, DateTime dateEnd)
        {
            return _context.WorkReports.Where(x => x.UserId == id && x.Date >= dateBegin && x.Date <= dateEnd).ToList();
           
        }

        public void Update(WorkReportModel workReport)
        {
            var hours = _context.WorkReports.Where(x => x.Id != workReport.Id && x.UserId == workReport.UserId && x.Date == workReport.Date).Sum(x => x.NumberOfHours) + workReport.NumberOfHours;
            if (hours > 24)
            {
                throw new Exception($"Ошибка: Сумма времени за день не может быть больше 24 часов");
            }

            _context.WorkReports.Update(workReport);
            Save();
        }
    }
}