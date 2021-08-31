using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Quartz;

namespace MetricsManager.Jobs
{
    [DisallowConcurrentExecution]
    public class CpuMetricJob : IJob
    {
        private readonly ICpuMetricRepository _repository;
        private readonly PerformanceCounter _performanceCounter;

        public CpuMetricJob(ICpuMetricRepository repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new CpuMetric()
            {
                ProcessorTimeTotal = Convert.ToInt32(_performanceCounter.NextValue()),
                Date = DateTime.Now
            });
            
            return Task.CompletedTask;
        }
        
        
    }
}