using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderHistoryMethodService
    {
        public Task<IEnumerable<OrderHistoryMethod>> GetAll();
    }
}
