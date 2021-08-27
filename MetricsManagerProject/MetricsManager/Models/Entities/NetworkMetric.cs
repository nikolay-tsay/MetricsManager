using System;

namespace MetricsManager.Models.Entities
{
    public class NetworkMetric : Entity<uint>
    {
        public int BytesPerSec { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}