using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services.Interfaces;
using MetricsManager.DTO;
using MetricsManager.Models.Entities;

namespace MetricsManager.DAL.Services
{
    internal sealed class DiskMetricService : IDiskMetricService
    {
        private readonly IDiskMetricRepository _repository;
        private readonly IMapper _mapper;

        public DiskMetricService(IDiskMetricRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<DiskMetricDto>> GetAll()
        {
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