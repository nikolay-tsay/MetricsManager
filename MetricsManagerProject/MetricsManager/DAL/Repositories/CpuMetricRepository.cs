using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsManager.DAL.Repositories
{
    internal sealed class CpuMetricRepository : ICpuMetricRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CpuMetricRepository> _logger;

        public CpuMetricRepository(ApplicationDbContext db, ILogger<CpuMetricRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        public async Task<IList<CpuMetric>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get request received in CpuMetricRepository");
                return await _db.CpuMetrics.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,"Application wasn't able to retrieve data");
                return null;
            }
        }

        public async Task Create(CpuMetric obj)
        {
            try
            {
                _logger.LogInformation("Creating new CpuMetric entity");
                _db.CpuMetrics.Add(obj);
                await _db.SaveChangesAsync();
                _logger.LogInformation("CpuMetric entity successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Application wasn't able to add entity");
            }
        }
    }
}