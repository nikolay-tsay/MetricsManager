using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Quartz;

namespace MetricsManager.Jobs
{
    [DisallowConcurrentExecution]
    public class MemoryMetricJob : IJob
    {
        private readonly IMemoryRepository _repository;
        private readonly PerformanceCounter _performanceCounter;

        public MemoryMetricJob(IMemoryRepository repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new AvailableMemoryMetric()
            {
                AvailableMBytes = Convert.ToInt32(_performanceCounter.NextValue()),
                Date = DateTime.Now
            });
            
            return Task.CompletedTask;
        }
    }
}