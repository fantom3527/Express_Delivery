using AutoMapper;
using ExpressDelivery.Domain;
using ExpressDelivery.Application.Common.Mapping;

namespace ExpressDelivery.Application.Dto.Order
{
    public record class CreateExecutorDto : IMapWith<Executor>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExecutorStatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateExecutorDto, Executor>()
                   .ForPath(Executor => Executor.Name,
                       opt => opt.MapFrom(createExecutorDto => createExecutorDto.Name))
                   .ForPath(Executor => Executor.Description,
                       opt => opt.MapFrom(createExecutorDto => createExecutorDto.Description))
                   .ForPath(Executor => Executor.ExecutorStatusId,
                       opt => opt.MapFrom(createExecutorDto => createExecutorDto.ExecutorStatusId));
        }
    }
}
