using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        public Task<IEnumerable<OrderHistory>> GetAll();
        public Task<IEnumerable<OrderHistory>> GetAllByOrder(Guid orderId);
    }
}
