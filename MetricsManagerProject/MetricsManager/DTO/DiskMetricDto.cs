using System;

namespace MetricsManager.DTO
{
    public class DiskMetricDto
    {
        public int IdleTimeTotal { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}