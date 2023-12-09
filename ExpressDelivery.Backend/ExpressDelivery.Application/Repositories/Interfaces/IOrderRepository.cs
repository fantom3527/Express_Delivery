using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default);
        public Task<Order> Get(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<Order>> GetQuery(string queryText, CancellationToken cancellationToken = default);
        public Task<Guid> Create(Order executor, CancellationToken cancellationToken = default);
        public Task Update(Order executor, CancellationToken cancellationToken = default);
        public Task UpdateStatus(Guid id, int orderStatusId, CancellationToken cancellationToken = default);
        public Task Delete(Guid id, int orderStatusDeleteId, CancellationToken cancellationToken = default);
        public Task AddExecutor(Guid orderId, Guid executorId, CancellationToken cancellationToken = default);

        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
