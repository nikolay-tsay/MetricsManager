using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace MetricsManager.Jobs.Services
{
    public class ScopedJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ScopedJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceProvider.GetRequiredService<QuartzJobRunner>();
        }

        public void ReturnJob(IJob job) { }
    }
}