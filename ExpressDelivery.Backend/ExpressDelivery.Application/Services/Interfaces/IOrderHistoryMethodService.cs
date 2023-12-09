using ExpressDelivery.Application.Dto.OrderHistoryMethodDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderHistoryMethodService
    {
        public Task<IEnumerable<GetOrderHistoryMethodDto>> GetAll(CancellationToken cancellationToken);
    }
}
