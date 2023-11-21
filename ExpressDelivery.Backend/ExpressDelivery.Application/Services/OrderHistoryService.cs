using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryService(IOrderHistoryRepository orderHistoryRepository)
            => _orderHistoryRepository = orderHistoryRepository;
        public async Task<IEnumerable<OrderHistory>> GetAll()
        {
            return await _orderHistoryRepository.GetAll();
        }

        public async Task<IEnumerable<OrderHistory>> GetAllByOrder(Guid orderId)
        {
            return await _orderHistoryRepository.GetAllByOrder(orderId);
        }
    }
}
