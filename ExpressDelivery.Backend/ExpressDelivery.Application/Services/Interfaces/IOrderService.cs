using ExpressDelivery.Application.Dto.OrderDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<GetOrderDto>> GetAll(CancellationToken cancellationToken);
        public Task<GetOrderDto> Get(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<GetOrderDto>> GetQuery(string queryText, CancellationToken cancellationToken);
        public Task<Guid> Create(CreateOrderDto order, CancellationToken cancellationToken);
        public Task Update(UpdateOrderDto order, CancellationToken cancellationToken);
        public Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus, CancellationToken cancellationToken);
        public Task Delete(Guid id, CancellationToken cancellationToken);
        public Task AddExecutor(Guid orderId, Guid executorId, CancellationToken cancellationToken);
    }
}
