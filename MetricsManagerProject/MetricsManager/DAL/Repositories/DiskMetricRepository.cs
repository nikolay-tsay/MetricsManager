using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class DiskMetricRepository : IDiskMetricRepository
    {
        private readonly ApplicationDbContext _db;

        public DiskMetricRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<PhysicalDiskMetric>> GetAll()
        {
            return await _db.DiskMetrics.ToListAsync();
        }

        public async Task Create(PhysicalDiskMetric obj)
        {
            _db.DiskMetrics.Add(obj);
            await _db.SaveChangesAsync();
        }
    }
}