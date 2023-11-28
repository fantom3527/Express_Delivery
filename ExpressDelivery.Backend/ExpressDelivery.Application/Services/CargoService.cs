using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
            => _cargoRepository = cargoRepository;

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _cargoRepository.GetAll();
        }

        public async Task<Cargo> Get(Guid id)
        {
            return await _cargoRepository.Get(id);
        }

        public async Task AddOrder(Guid id, Guid orderId)
        {
            await _cargoRepository.AddOrder(id, orderId);
            await _cargoRepository.SaveChangesAsync();
        }
    }
}
