using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class NetworkMetricRepository : INetworkMetricRepository
    {
        private readonly ApplicationDbContext _db;

        public NetworkMetricRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<NetworkMetric>> GetAll()
        {
            return await _db.NetworkMetrics.ToListAsync();
        }

        public async Task Create(NetworkMetric obj)
        {
            _db.NetworkMetrics.Add(obj);
            await _db.SaveChangesAsync();
        }
    }
}