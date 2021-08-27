using System;

namespace MetricsManager.Models.Entities
{
    public class CpuMetric : Entity<uint>
    {
        public int ProcessorTimeTotal { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}