using AutoMapper;
using ExpressDelivery.Domain;
using ExpressDelivery.Application.Common.Mapping;

namespace ExpressDelivery.Application.Dto.ExecutorDto
{
    public record class UpdateExecutorDto : IMapWith<Executor>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateExecutorDto, Executor>()
                   .ForPath(Executor => Executor.Id,
                       opt => opt.MapFrom(updateExecutorDto => updateExecutorDto.Id))
                   .ForPath(Executor => Executor.Name,
                       opt => opt.MapFrom(updateExecutorDto => updateExecutorDto.Name))
                   .ForPath(Executor => Executor.Description,
                       opt => opt.MapFrom(updateExecutorDto => updateExecutorDto.Description));
        }
    }
}
