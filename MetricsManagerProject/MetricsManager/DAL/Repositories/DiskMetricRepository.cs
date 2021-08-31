using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class DiskMetricRepository : IDiskMetricRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DiskMetricRepository> _logger;

        public DiskMetricRepository(ApplicationDbContext db, ILogger<DiskMetricRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        public async Task<IList<PhysicalDiskMetric>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get request received in DiskMetricRepository");
                return await _db.DiskMetrics.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,"Application wasn't able to retrieve data");
                return null;
            }
        }

        public async Task Create(PhysicalDiskMetric obj)
        {
            try
            {
                _logger.LogInformation("Creating new DiskMetric entity");
                _db.DiskMetrics.Add(obj);
                await _db.SaveChangesAsync();
                _logger.LogInformation("DiskMetric entity successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Application wasn't able to add entity");
            }
        }
    }
}