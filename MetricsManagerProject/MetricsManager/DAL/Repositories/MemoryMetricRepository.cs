using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.Controllers;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class MemoryMetricRepository : IMemoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MemoryMetricRepository> _logger;

        public MemoryMetricRepository(ApplicationDbContext db, ILogger<MemoryMetricRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        public async Task<IList<AvailableMemoryMetric>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get request received in MemoryMetricRepository");
                return await _db.MemoryMetrics.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,"Application wasn't able to retrieve data");
                return null;
            }
        }

        public async Task Create(AvailableMemoryMetric obj)
        {
            try
            {
                _logger.LogInformation("Creating new MemoryMetric entity");
                _db.MemoryMetrics.Add(obj);
                await _db.SaveChangesAsync();
                _logger.LogInformation("MemoryMetric successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Application wasn't able to add entity");
            }
        }
        
    }
}