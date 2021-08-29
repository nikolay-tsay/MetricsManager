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
    internal sealed class NetworkMetricService : INetworkMetricService
    {
        private readonly INetworkMetricRepository _repository;
        private readonly IMapper _mapper;

        public NetworkMetricService(INetworkMetricRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<NetworkMetricDto>> GetAll()
        {
            IList<NetworkMetric> sourceList = await _repository.GetAll();
            
            IList<NetworkMetricDto> output = new List<NetworkMetricDto>();

            foreach (var metric in sourceList)
            {
                output.Add(_mapper.Map<NetworkMetricDto>(metric));
            }

            return output;
        }
    }
}