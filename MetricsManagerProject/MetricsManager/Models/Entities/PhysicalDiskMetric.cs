using System;

namespace MetricsManager.Models.Entities
{
    public class PhysicalDiskMetric : Entity<uint>
    {
        public int IdleTimeTotal { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}