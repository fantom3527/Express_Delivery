using AutoMapper;
using ExpressDelivery.Application.Dto.CargoDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
            => (_cargoRepository, _mapper) = (cargoRepository, mapper);

        public async Task<IEnumerable<GetCargoDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GetCargoDto>>(await _cargoRepository.GetAll());
        }

        public async Task<GetCargoDto> Get(Guid id)
        {
            return _mapper.Map<GetCargoDto>(await _cargoRepository.Get(id));
        }

        public async Task AddOrder(Guid id, Guid orderId)
        {
            await _cargoRepository.AddOrder(id, orderId);
            await _cargoRepository.SaveChangesAsync();
        }
    }
}
