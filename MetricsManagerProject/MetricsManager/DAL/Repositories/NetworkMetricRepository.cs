using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Z.EntityFramework.Plus;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class NetworkMetricRepository : INetworkMetricRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<NetworkMetricRepository> _logger;

        public NetworkMetricRepository(ApplicationDbContext db, ILogger<NetworkMetricRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        public async Task<IList<NetworkMetric>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get request received in NetworkMetricRepository");
                return await _db.NetworkMetrics.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,"Application wasn't able to retrieve data");
                return null;
            }
        }

        public async Task Create(NetworkMetric obj)
        {
            try
            {
                _logger.LogInformation("Creating new NetworkMetric entity");
                _db.NetworkMetrics.Add(obj);
                await _db.SaveChangesAsync();
                _logger.LogInformation("NetworkMetric entity successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Application wasn't able to add entity");
            }
        }
        
    }
}