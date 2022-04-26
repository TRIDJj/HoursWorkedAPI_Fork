using HoursWorkedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoursWorkedAPI.DBData.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WorkReportModel> WorkReports { get; set; }
    }
}