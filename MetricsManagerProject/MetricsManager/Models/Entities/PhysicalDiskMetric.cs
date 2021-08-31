using System;

namespace MetricsManager.Models.Entities
{
    public class PhysicalDiskMetric : Entity<int>
    {
        public int IdleTimeTotal { get; set; }

        public DateTime Date { get; set; }
    }
}