using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order> Get(Guid id);
        public Task<IEnumerable<Order>> GetQuery(string queryText);
        public Task<Guid> Create(Order order);
        public Task Update(Order order);
        public Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus);
        public Task Delete(Guid id);
        public Task AssignmentExecutor(Guid orderId, Guid executorId);
    }
}
