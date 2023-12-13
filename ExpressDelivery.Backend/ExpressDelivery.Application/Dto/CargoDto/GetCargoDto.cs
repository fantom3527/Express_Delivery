using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.CargoDto
{
    public record class GetCargoDto : IMapWith<Cargo>
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public int CargoTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cargo, GetCargoDto>()
                   .ForPath(getCargoDto => getCargoDto.Id,
                       opt => opt.MapFrom(cargo => cargo.Id))
                   .ForPath(getCargoDto => getCargoDto.OrderId,
                       opt => opt.MapFrom(cargo => cargo.OrderId))
                   .ForPath(getCargoDto => getCargoDto.CargoTypeId,
                       opt => opt.MapFrom(cargo => cargo.CargoTypeId))
                   .ForPath(getCargoDto => getCargoDto.Name,
                       opt => opt.MapFrom(cargo => cargo.Name))
                   .ForPath(getCargoDto => getCargoDto.Description,
                       opt => opt.MapFrom(cargo => cargo.Description));
        }
    }
}
