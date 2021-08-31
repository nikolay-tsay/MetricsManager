using System;

namespace MetricsManager.Models.Entities
{
    public class NetworkMetric : Entity<int>
    {
        public int BytesPerSec { get; set; }

        public DateTime Date { get; set; }
    }
}