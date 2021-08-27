

using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<CpuMetric> CpuMetrics { get; set; }

        public DbSet<NetworkMetric> NetworkMetrics { get; set; }

        public DbSet<PhysicalDiskMetric> DiskMetrics { get; set; }

        public DbSet<AvailableMemoryMetric> MemoryMetrics { get; set; }
    }
}