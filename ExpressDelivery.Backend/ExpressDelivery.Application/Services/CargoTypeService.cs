using AutoMapper;
using ExpressDelivery.Application.Dto.CargoTypeDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class CargoTypeService : ICargoTypeService
    {
        private readonly ICargoTypeRepository _cargoTypeRepository;
        private readonly IMapper _mapper;

        public CargoTypeService(ICargoTypeRepository cargoTypeRepository, IMapper mapper)
            => (_cargoTypeRepository, _mapper) = (cargoTypeRepository, mapper);

        public async Task<IEnumerable<GetCargoTypeDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetCargoTypeDto>>(await _cargoTypeRepository.GetAll(cancellationToken));
        }
    }
}
