using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.CargoTypeDto
{
    public record class GetCargoTypeDto : IMapWith<CargoType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CargoType, GetCargoTypeDto>()
                   .ForPath(getCargoTypeDto => getCargoTypeDto.Id,
                       opt => opt.MapFrom(cargoType => cargoType.Id))
                   .ForPath(getCargoTypeDto => getCargoTypeDto.Name,
                       opt => opt.MapFrom(cargoType => cargoType.Name))
                   .ForPath(getCargoTypeDto => getCargoTypeDto.Code,
                       opt => opt.MapFrom(cargoType => cargoType.Code))
                   .ForPath(getCargoTypeDto => getCargoTypeDto.IsActual,
                       opt => opt.MapFrom(cargoType => cargoType.IsActual));
        }
    }
}
