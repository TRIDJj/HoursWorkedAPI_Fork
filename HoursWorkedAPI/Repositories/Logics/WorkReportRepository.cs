using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HoursWorkedAPI.DBData.Database;
using HoursWorkedAPI.DBData.DTOModels;
using HoursWorkedAPI.Models;
using HoursWorkedAPI.Repositories.Interfaces;

namespace HoursWorkedAPI.Repositories.Logics
{
    public class WorkReportRepository : IWorkReportRepository
    {
        private IMapper mapper;
        private ApplicationContext context;
        public WorkReportRepository(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Создание отчета о работе за день.
        /// </summary>
        /// <param name="work">структура типа WorkReport.</param>
        /// <returns>
        /// При успешном создании записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Create(WorkReportModel work)
        {
             try
             {
                var hours = context.WorkReports.Where(x => x.UserId == work.UserId && x.Date == work.Date).Sum(x => x.NumberOfHours) + work.NumberOfHours;
                if (hours <= 24)
                {
                    var newWork = mapper.Map<WorkReportDTO>(work);
                    context.WorkReports.Add(newWork);
                    context.SaveChanges();
                    return $"work_guid: {newWork.Id}";
                }
                return $"Ошибка: Сумма времени за день не может быть больше 24 часов";
            }
             catch (Exception e)
             {
                 return $"Ошибка: {e.Message}";
             }
        }

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="id">идентификатор работы.</param>
        /// <returns>
        /// При успешном удалении записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Delete(Guid id)
        {
            try
            {
                var result = context.WorkReports.Single(x => x.Id == id);
                context.WorkReports.Remove(result);
                context.SaveChanges();
                return $"Данные по guid {id} удалены"; ;
            }
            catch (Exception e)
            {
                return $"Ошибка: {e.Message}";
            }
        }
        
        /// <summary>
        /// Получение записей по id пользователя и дате.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="date">Дата.</param>
        /// <returns>
        /// Возвращает список работ пользователя за месяц.
        /// </returns>
        public List<WorkReportModel> Get(Guid id, DateTime dateBegin, DateTime dateEnd)
        {
            var listWorkDTO = context.WorkReports.Where(x => x.UserId == id && x.Date >= dateBegin && x.Date <= dateEnd).ToList();
            var listWork = mapper.Map<List<WorkReportModel>>(listWorkDTO);
            return listWork;
        }

        /// <summary>
        /// Изменение записи. 
        /// </summary>
        /// <param name="work">структура типа WorkReport.</param>
        /// <returns>
        /// При успешном создании записи возвращает строку с id записи.
        /// Иначе возвращает ошибку.
        /// </returns>
        public string Update(WorkReportModel work)
        {
            try
            {
                var hours = context.WorkReports.Where(x => x.Id != work.Id && x.UserId == work.UserId && x.Date == work.Date ).Sum(x => x.NumberOfHours) + work.NumberOfHours;
                if (hours <= 24)
                {
                    var changeableWork = mapper.Map<WorkReportDTO>(work);
                    context.WorkReports.Update(changeableWork);
                    context.SaveChanges();
                    return $"work_guid: {changeableWork.UserId} изменен";
                }
                return $"Ошибка: Сумма времени за день не может быть больше 24 часов";
            }
            catch (Exception e)
            {
                return $"Ошибка: {e.Message}";
            }
        }
    }
}
