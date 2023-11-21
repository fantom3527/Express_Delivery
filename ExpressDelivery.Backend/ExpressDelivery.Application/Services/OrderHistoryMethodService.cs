using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class OrderHistoryMethodService : IOrderHistoryMethodService
    {
        private readonly IOrderHistoryMethodRepository _orderHistoryMethodRepository;

        public OrderHistoryMethodService(IOrderHistoryMethodRepository orderHistoryMethodRepository)
            => _orderHistoryMethodRepository = orderHistoryMethodRepository;
        public async Task<IEnumerable<OrderHistoryMethod>> GetAll()
        {
            return await _orderHistoryMethodRepository.GetAll();
        }
    }
}
