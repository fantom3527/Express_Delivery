using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderHistoryRepository
    {
        public Task<IEnumerable<OrderHistory>> GetAll();
        public Task<IEnumerable<OrderHistory>> GetOrderAll(Guid OrderId);
        public Task<OrderHistory> Get(Guid Id);
        public Task<Guid> Create(OrderHistory orderHistory);

        public Task SaveChangesAsync();
    }
}
