using HoursWorkedAPI.DBData.Database;
using HoursWorkedAPI.Interfaces;
using HoursWorkedAPI.Middleware;
using HoursWorkedAPI.Repositories;
using HoursWorkedAPI.Repositories.Mappers;
using HoursWorkedAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HoursWorkedAPI
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            // Mssql
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            // Post
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));
            
            services.AddAutoMapper(typeof(UserConfigureProfile));
            
            services.AddTransient<UserRepository>();
            services.AddTransient<WorkReportRepository>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IWorkReportManager, WorkReportManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}