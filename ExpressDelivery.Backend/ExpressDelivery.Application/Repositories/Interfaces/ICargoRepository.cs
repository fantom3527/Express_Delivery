using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface ICargoRepository
    {
        public Task<IEnumerable<Cargo>> GetAll();
        public Task<Cargo> Get(Guid id);
    }
}
