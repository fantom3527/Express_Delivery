using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderStatusService
    {
        public Task<IEnumerable<OrderStatus>> GetAll();
    }
}
