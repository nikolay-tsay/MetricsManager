using System;

namespace MetricsManager.DTO
{
    public class NetworkMetricDto
    {
        public int BytesPerSec { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}