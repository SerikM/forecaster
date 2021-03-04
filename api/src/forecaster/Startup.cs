using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Amazon.XRay.Recorder.Core;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Forecaster.Models;
using Forecaster.Services;
using Data.Sql.EF;
using Data.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forecaster
{
    public class Startup
    {
        readonly string CorsPolicyName = "_corsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AWSXRayRecorder.InitializeInstance(configuration);
        }

        public IConfigurationRoot ConfigurationRoot { get; set; }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName,
                                  builder => { builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); });
            });
            services.AddOptions();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.Configure<AwsSettingsModel>(Configuration.GetSection("AWS"));
            AWSSDKHandler.RegisterXRayForAllServices();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddControllers();
            services.AddDbContext<ForecasterContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AuroraConnection")));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors(CorsPolicyName);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
