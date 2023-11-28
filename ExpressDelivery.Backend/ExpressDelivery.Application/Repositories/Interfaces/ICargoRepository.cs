using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface ICargoRepository
    {
        public Task<IEnumerable<Cargo>> GetAll();
        public Task<Cargo> Get(Guid id);
        public Task AddOrder(Guid id, Guid orderId);
        public Task SaveChangesAsync();
    }
}
