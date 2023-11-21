using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface ICargoTypeRepository
    {
        public Task<IEnumerable<CargoType>> GetAll();
    }
}
