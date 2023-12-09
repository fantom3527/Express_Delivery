using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface ICargoRepository
    {
        public Task<IEnumerable<Cargo>> GetAll(CancellationToken cancellationToken = default);
        public Task<Cargo> Get(Guid id, CancellationToken cancellationToken = default);
        public Task AddOrder(Guid id, Guid orderId, CancellationToken cancellationToken = default);
        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
