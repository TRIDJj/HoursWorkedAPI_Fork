using AutoMapper;
using HoursWorkedAPI.DBData.DTOModels;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repository.Mappers
{
    public class UserConfigureProfile : Profile
    {
        public UserConfigureProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<WorkReport, WorkReportDTO>();
            CreateMap<WorkReportDTO, WorkReport>();
        }
    }
}
