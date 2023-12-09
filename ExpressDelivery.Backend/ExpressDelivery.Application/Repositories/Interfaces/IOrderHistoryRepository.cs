using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderHistoryRepository
    {
        public Task<IEnumerable<OrderHistory>> GetAll(CancellationToken cancellationToken = default);
        public Task<IEnumerable<OrderHistory>> GetAllByOrder(Guid OrderId, CancellationToken cancellationToken = default);
        public Task<OrderHistory> Get(Guid Id, CancellationToken cancellationToken = default);
        public Task<Guid> Create(OrderHistory orderHistory, CancellationToken cancellationToken = default);

        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
