using System;

namespace MetricsManager.DTO
{
    public class MemoryMetricDto
    {
        public int AvailableMBytes { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}