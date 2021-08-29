using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Quartz;

namespace MetricsManager.Jobs
{
    [DisallowConcurrentExecution]
    public class NetworkMetricJob : IJob
    {
        private readonly INetworkMetricRepository _repository;
        private readonly PerformanceCounter _performanceCounter;

        public NetworkMetricJob(INetworkMetricRepository repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Network Interface","Bytes Total/sec", "Intel[R] Dual Band Wireless-AC 8260");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _repository.Create(new NetworkMetric()
            {
                BytesPerSec = Convert.ToInt32(_performanceCounter.NextValue()),
                Date = DateTime.Now
            });

            return Task.CompletedTask;
        }
    }    
}