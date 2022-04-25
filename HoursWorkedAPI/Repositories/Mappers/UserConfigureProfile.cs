using AutoMapper;
using HoursWorkedAPI.DBData.DTOModels;
using HoursWorkedAPI.Models;

namespace HoursWorkedAPI.Repositories.Mappers
{
    public class UserConfigureProfile : Profile
    {
        public UserConfigureProfile() 
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, UserModel>();
            CreateMap<WorkReportModel, WorkReportDTO>();
            CreateMap<WorkReportDTO, WorkReportModel>();
        }
    }
}
