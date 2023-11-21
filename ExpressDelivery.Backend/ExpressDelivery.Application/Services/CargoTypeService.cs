using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class CargoTypeService : ICargoTypeService
    {
        private readonly ICargoTypeRepository _cargoTypeRepository;

        public CargoTypeService(ICargoTypeRepository cargoTypeRepository)
            => _cargoTypeRepository = cargoTypeRepository;
        public async Task<IEnumerable<CargoType>> GetAll()
        {
            return await _cargoTypeRepository.GetAll();
        }
    }
}
