using AutoMapper;
using ExpressDelivery.Application.Dto.OrderHistoryMethodDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class OrderHistoryMethodService : IOrderHistoryMethodService
    {
        private readonly IOrderHistoryMethodRepository _orderHistoryMethodRepository;
        private readonly IMapper _mapper;

        public OrderHistoryMethodService(IOrderHistoryMethodRepository orderHistoryMethodRepository, IMapper mapper)
            => (_orderHistoryMethodRepository, _mapper) = (orderHistoryMethodRepository, mapper);

        public async Task<IEnumerable<GetOrderHistoryMethodDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GetOrderHistoryMethodDto>>(await _orderHistoryMethodRepository.GetAll());
        }
    }
}
