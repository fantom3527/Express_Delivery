using ExpressDelivery.Application.Dto.OrderHistoryDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        public Task<IEnumerable<GetOrderHistoryDto>> GetAll();
        public Task<IEnumerable<GetOrderHistoryDto>> GetAllByOrder(Guid orderId);
    }
}
