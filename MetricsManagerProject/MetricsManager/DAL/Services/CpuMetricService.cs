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
    internal sealed class CpuMetricService : ICpuMetricService
    {
        private readonly ICpuMetricRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CpuMetricService> _logger;

        public CpuMetricService(ICpuMetricRepository repository, IMapper mapper, ILogger<CpuMetricService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<IList<CpuMetricDto>> GetAll()
        {
            _logger.LogInformation("Get method called from CpuMetricService");
            
            IList<CpuMetric> sourceList = await _repository.GetAll();

            IList<CpuMetricDto> output = new List<CpuMetricDto>();
            
            foreach (var metric in sourceList)
            {
                output.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            return output;
        }
    }
}