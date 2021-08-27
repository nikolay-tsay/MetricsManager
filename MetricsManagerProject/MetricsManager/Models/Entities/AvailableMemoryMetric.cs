using System;

namespace MetricsManager.Models.Entities
{
    public class AvailableMemoryMetric : Entity<uint>
    {
        public int AvailableMBytes { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}