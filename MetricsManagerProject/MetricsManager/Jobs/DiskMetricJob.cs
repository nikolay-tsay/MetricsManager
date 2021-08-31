using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Quartz;

namespace MetricsManager.Jobs
{
    [DisallowConcurrentExecution]
    public class DiskMetricJob : IJob
    {
        private readonly IDiskMetricRepository _repository;
        private readonly PerformanceCounter _performanceCounter;

        public DiskMetricJob(IDiskMetricRepository repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("PhysicalDisk","% Idle Time","_Total");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new PhysicalDiskMetric()
            {
                IdleTimeTotal = Convert.ToInt32(_performanceCounter.NextValue()),
                Date = DateTime.Now
            });
            
            return Task.CompletedTask;
        }
    }
}