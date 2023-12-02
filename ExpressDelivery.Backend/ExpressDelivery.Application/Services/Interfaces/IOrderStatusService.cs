using ExpressDelivery.Application.Dto.OrderStatusDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderStatusService
    {
        public Task<IEnumerable<GetOrderStatusDto>> GetAll();
    }
}
