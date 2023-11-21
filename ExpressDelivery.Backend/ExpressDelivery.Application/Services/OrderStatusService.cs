using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
            => _orderStatusRepository = orderStatusRepository;
        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _orderStatusRepository.GetAll();
        }
    }
}
