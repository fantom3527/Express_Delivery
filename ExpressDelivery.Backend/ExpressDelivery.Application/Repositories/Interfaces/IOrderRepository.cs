using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order> Get(Guid id);
        public Task<IEnumerable<Order>> GetQuery(string queryText);
        public Task<Guid> Create(Order executor);
        public Task Update(Order executor);
        public Task UpdateStatus(Guid id, int orderStatusId);
        public Task Delete(Guid id, int orderStatusDeleteId);
        public Task AssignmentExecutor(Guid orderId, Guid executorId);

        public Task SaveChangesAsync();
    }
}
