using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class CpuMetricRepository : ICpuMetricRepository
    {
        private readonly ApplicationDbContext _db;

        public CpuMetricRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<CpuMetric>> GetAll()
        {
            return await _db.CpuMetrics.ToListAsync();
        }

        public async Task Create(CpuMetric obj)
        {
            _db.CpuMetrics.Add(obj);
            await _db.SaveChangesAsync();
        }
    }
}