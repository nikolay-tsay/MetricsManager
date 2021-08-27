using System;

namespace MetricsManager.Models.Entities
{
    public class AvailableMemoryMetric : Entity<int>
    {
        public int AvailableMBytes { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}