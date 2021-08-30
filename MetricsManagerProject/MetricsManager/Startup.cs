using AutoMapper;
using MetricsManager.DAL;
using MetricsManager.DAL.Repositories;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services;
using MetricsManager.DAL.Services.Interfaces;
using MetricsManager.DTO;
using MetricsManager.Jobs;
using MetricsManager.Jobs.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Serilog;

namespace MetricsManager
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
            services.AddScoped<ICpuMetricRepository, CpuMetricRepository>();
            services.AddScoped<IMemoryRepository, MemoryMetricRepository>();
            services.AddScoped<IDiskMetricRepository, DiskMetricRepository>();
            services.AddScoped<INetworkMetricRepository, NetworkMetricRepository>();

            services.AddScoped<ICpuMetricService, CpuMetricService>();
            services.AddScoped<IMemoryMetricService, MemoryMetricService>();
            services.AddScoped<IDiskMetricService, DiskMetricService>();
            services.AddScoped<INetworkMetricService, NetworkMetricService>();

            services.AddSingleton<IJobFactory, ScopedJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            
            services.AddSingleton<QuartzJobRunner>();
            services.AddHostedService<QuartzHostedService>();

            services.AddScoped<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?"));
            
            services.AddScoped<MemoryMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(MemoryMetricJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddScoped<DiskMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DiskMetricJob),
                cronExpression: "0/5 * * * * ?"));
            
            services.AddScoped<NetworkMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: "0/5 * * * * ?"));
            
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsManager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsManager v1"));
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}