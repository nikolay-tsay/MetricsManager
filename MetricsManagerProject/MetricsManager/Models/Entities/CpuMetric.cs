using System;

namespace MetricsManager.Models.Entities
{
    public class CpuMetric : Entity<int>
    {
        public int ProcessorTimeTotal { get; set; }

        public DateTime Date { get; set; }
    }
}