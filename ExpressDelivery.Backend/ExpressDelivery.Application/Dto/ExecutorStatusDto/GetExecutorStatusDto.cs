using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.ExecutorStatusDto
{
    public class GetExecutorStatusDto : IMapWith<ExecutorStatus>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExecutorStatus, GetExecutorStatusDto>()
                   .ForPath(getExecutorStatusDto => getExecutorStatusDto.Id,
                       opt => opt.MapFrom(executorStatus => executorStatus.Id))
                   .ForPath(getExecutorStatusDto => getExecutorStatusDto.Name,
                       opt => opt.MapFrom(executorStatus => executorStatus.Name))
                   .ForPath(getExecutorStatusDto => getExecutorStatusDto.Code,
                       opt => opt.MapFrom(executorStatus => executorStatus.Code))
                   .ForPath(getExecutorStatusDto => getExecutorStatusDto.IsActual,
                       opt => opt.MapFrom(executorStatus => executorStatus.IsActual));
        }
    }
}
