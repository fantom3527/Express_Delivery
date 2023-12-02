using AutoMapper;
using ExpressDelivery.Application.Dto.OrderStatusDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
            => (_orderStatusRepository, _mapper) = (orderStatusRepository, mapper);
        public async Task<IEnumerable<GetOrderStatusDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GetOrderStatusDto>>(await _orderStatusRepository.GetAll());
        }
    }
}
