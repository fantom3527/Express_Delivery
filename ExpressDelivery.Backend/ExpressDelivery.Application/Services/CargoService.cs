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

        public async Task<IEnumerable<GetCargoDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetCargoDto>>(await _cargoRepository.GetAll(cancellationToken));
        }

        public async Task<GetCargoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetCargoDto>(await _cargoRepository.Get(id, cancellationToken));
        }

        public async Task AddOrder(Guid id, Guid orderId, CancellationToken cancellationToken)
        {
            await _cargoRepository.AddOrder(id, orderId, cancellationToken);
            await _cargoRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
