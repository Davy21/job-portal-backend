using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Randstad.JobApplication.Service.Data;
using Microsoft.EntityFrameworkCore;
using Randstad.JobApplication.Service.Repositories.IConfiguration;
using Randstad.JobApplication.Service.Repositories;
using Randstad.JobApplication.Service.Services.IServices;
using Randstad.JobApplication.Service.Services;

namespace Randstad.JobApplication.Service
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
            services.AddDbContext<JobContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<JobContext>(opt =>
                  //opt.UseInMemoryDatabase("Job"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUploadFileService, DropBoxServices>();

            services.AddCors();

            services.AddHealthChecks();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var corsAllowedList = Configuration.GetSection("CorsAllowedHosts").Get<string[]>();

            app.UseCors(options => {
                options.WithOrigins(corsAllowedList)
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
