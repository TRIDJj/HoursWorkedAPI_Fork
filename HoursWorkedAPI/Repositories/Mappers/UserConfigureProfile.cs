using AutoMapper;
using HoursWorkedAPI.Models;
using HoursWorkedAPI.ViewModels;

namespace HoursWorkedAPI.Repositories.Mappers
{
    public class UserConfigureProfile : Profile
    {
        public UserConfigureProfile() 
        {
            CreateMap<UserViewModel, UserModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<WorkReportViewModel, WorkReportModel>();
            CreateMap<WorkReportModel, WorkReportViewModel>();
        }
    }
}
