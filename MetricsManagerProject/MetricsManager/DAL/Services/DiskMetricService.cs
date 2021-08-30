using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services.Interfaces;
using MetricsManager.DTO;
using MetricsManager.Models.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsManager.DAL.Services
{
    internal sealed class DiskMetricService : IDiskMetricService
    {
        private readonly IDiskMetricRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiskMetricService> _logger;

        public DiskMetricService(IDiskMetricRepository repository, IMapper mapper, ILogger<DiskMetricService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<IList<DiskMetricDto>> GetAll()
        {
            _logger.LogInformation("Get method called from DiskMetricService");
            
            IList<PhysicalDiskMetric> sourceList = await _repository.GetAll();

            IList<DiskMetricDto> output = new List<DiskMetricDto>();

            foreach (var metric in sourceList)
            {
                output.Add(_mapper.Map<DiskMetricDto>(metric));
            }

            return output;
        }
    }
}