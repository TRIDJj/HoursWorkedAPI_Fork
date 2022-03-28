using HoursWorkedAPI.DBData.DTOModels;
using Microsoft.EntityFrameworkCore;

namespace HoursWorkedAPI.DBData.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<WorkReportDTO> WorkReports { get; set; }
    }
}
