using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.ExecutorDto
{
    public class GetExecutorDto : IMapWith<Executor>
    {
        public Guid Id { get; set; }
        public int ExecutorStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Executor, GetExecutorDto>()
                   .ForPath(updateExecutorDto => updateExecutorDto.Id,
                       opt => opt.MapFrom(executor => executor.Id))
                   .ForPath(updateExecutorDto => updateExecutorDto.ExecutorStatusId,
                       opt => opt.MapFrom(executor => executor.ExecutorStatusId))
                   .ForPath(updateExecutorDto => updateExecutorDto.Name,
                       opt => opt.MapFrom(executor => executor.Name))
                   .ForPath(updateExecutorDto => updateExecutorDto.Description,
                       opt => opt.MapFrom(executor => executor.Description));
        }
    }
}
