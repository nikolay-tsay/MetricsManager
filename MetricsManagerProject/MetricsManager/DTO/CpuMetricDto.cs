using System;

namespace MetricsManager.DTO
{
    public class CpuMetricDto
    {
        public int ProcessorTimeTotal { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}