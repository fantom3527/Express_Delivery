using AutoMapper;
using ExpressDelivery.Application.Dto.OrderHistoryDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IMapper _mapper;

        public OrderHistoryService(IOrderHistoryRepository orderHistoryRepository, IMapper mapper)
            => (_orderHistoryRepository, _mapper) = (orderHistoryRepository, mapper);

        public async Task<IEnumerable<GetOrderHistoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetOrderHistoryDto>>(await _orderHistoryRepository.GetAll(cancellationToken));
        }

        public async Task<IEnumerable<GetOrderHistoryDto>> GetAllByOrder(Guid orderId, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetOrderHistoryDto>>(await _orderHistoryRepository.GetAllByOrder(orderId, cancellationToken));
        }
    }
}
