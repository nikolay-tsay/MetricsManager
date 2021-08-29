using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class MemoryMetricRepository : IMemoryRepository
    {
        private readonly ApplicationDbContext _db;

        public MemoryMetricRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<AvailableMemoryMetric>> GetAll()
        {
            return await _db.MemoryMetrics.ToListAsync();
        }

        public async Task Create(AvailableMemoryMetric obj)
        {
            _db.MemoryMetrics.Add(obj);
            await _db.SaveChangesAsync();
        }
        
    }
}