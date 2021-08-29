using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services.Interfaces;
using MetricsManager.DTO;
using MetricsManager.Models.Entities;

namespace MetricsManager.DAL.Services
{
    public class CpuMetricService : ICpuMetricService
    {
        private readonly ICpuMetricRepository _repository;
        private readonly IMapper _mapper;

        public CpuMetricService(ICpuMetricRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<CpuMetricDto>> GetAll()
        {
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