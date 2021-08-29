using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services.Interfaces;
using MetricsManager.DTO;
using MetricsManager.Models.Entities;

namespace MetricsManager.DAL.Services
{
    internal sealed class MemoryMetricService : IMemoryMetricService
    {
        private readonly IMemoryRepository _repository;
        private readonly IMapper _mapper;

        public MemoryMetricService(IMemoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<MemoryMetricDto>> GetAll()
        {
            IList<AvailableMemoryMetric> sourceList = await _repository.GetAll();

            IList<MemoryMetricDto> output = new List<MemoryMetricDto>();

            foreach (var metric in sourceList)
            {
                output.Add(_mapper.Map<MemoryMetricDto>(metric));
            }

            return output;
        }
    }
}