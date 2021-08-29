using AutoMapper;
using MetricsManager.Jobs;
using MetricsManager.Models.Entities;

namespace MetricsManager.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>().ForSourceMember(
                x => x.Id, opt => opt.DoNotValidate());

            CreateMap<PhysicalDiskMetric, DiskMetricDto>().ForSourceMember(
                x => x.Id, opt => opt.DoNotValidate());

            CreateMap<NetworkMetric, NetworkMetricDto>().ForSourceMember(
                x=> x.Id, opt => opt.DoNotValidate());

            CreateMap<AvailableMemoryMetric, MemoryMetricDto>().ForSourceMember(
                x => x.Id, opt => opt.DoNotValidate());

        }
    }
}