using ExpressDelivery.Application.Dto.OrderDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<GetOrderDto>> GetAll();
        public Task<GetOrderDto> Get(Guid id);
        public Task<IEnumerable<GetOrderDto>> GetQuery(string queryText);
        public Task<Guid> Create(CreateOrderDto order);
        public Task Update(UpdateOrderDto order);
        public Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus);
        public Task Delete(Guid id);
        public Task AddExecutor(Guid orderId, Guid executorId);
    }
}
