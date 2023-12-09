using AutoMapper;
using ExpressDelivery.Application.Dto.OrderDto;
using ExpressDelivery.Application.Managers.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
            => (_repositoryManager, _mapper) = (repositoryManager, mapper);

        public async Task<IEnumerable<GetOrderDto>> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _repositoryManager.OrderRepository.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }
        public async Task<GetOrderDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetOrderDto>(await _repositoryManager.OrderRepository.Get(id, cancellationToken));
        }

        public async Task<IEnumerable<GetOrderDto>> GetQuery(string queryText, CancellationToken cancellationToken)
        {
            var orders = await _repositoryManager.OrderRepository.GetQuery(queryText, cancellationToken);

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }

        public async Task<Guid> Create(CreateOrderDto order, CancellationToken cancellationToken)
        {
            Guid id = await CreateOrder(_mapper.Map<Order>(order), cancellationToken);
            //TODO: Исправить на Enum
            await CreateOrderHistory(id, "create", cancellationToken);
            await _repositoryManager.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task Update(UpdateOrderDto order, CancellationToken cancellationToken)
        {
            // TODO: Реализация пробрасывания своего исключения, если статус при обновлении данных не новый.
            if (!await AllowEdit(order.OrderStatusId, cancellationToken))
                return;

            await _repositoryManager.OrderRepository.Update(_mapper.Map<Order>(order), cancellationToken);
            //TODO: Исправить на Enum
            await CreateOrderHistory(order.Id, "edit", cancellationToken);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus, CancellationToken cancellationToken)
        {
            await _repositoryManager.OrderRepository.UpdateStatus(id, orderStatusId, cancellationToken);
            //TODO: Исправить на Enum
            await CreateOrderHistory(id, "updatestatus", cancellationToken, descriptionUpdateStatus);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            //TODO: Исправить на Enum
            await _repositoryManager.OrderRepository.Delete(id, await GetOrderStatusId("deleted", cancellationToken));
            await CreateOrderHistory(id, "delete", cancellationToken);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task AddExecutor(Guid orderId, Guid executorId, CancellationToken cancellationToken)
        {
            await _repositoryManager.OrderRepository.AddExecutor(orderId, executorId, cancellationToken);
            //TODO: Исправить на Enum
            await _repositoryManager.OrderRepository.UpdateStatus(orderId, await GetOrderStatusId("submitted", cancellationToken), cancellationToken);
            await _repositoryManager.ExecutorRepository.UpdateStatus(executorId, await GetExecutorStatusId("executesorder", cancellationToken), cancellationToken);
            await CreateOrderHistory(orderId, "submittedexecution", cancellationToken);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        private async Task<Guid> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            order.OrderStatusId = await GetOrderStatusId("new", cancellationToken);

            return await _repositoryManager.OrderRepository.Create(order, cancellationToken);
        }

        //TODO: Добавить добавление поля, кто сделал изменения: Исполнитель, заказчик или система (Их Id).
        private async Task CreateOrderHistory(Guid orderId, string orderHistoryMethodCode, CancellationToken cancellationToken, string? OrderHistoryDescription = null)
        {
            //TODO: Добавить проверку, если нет в списке нужных методов по коду
            int orderHistoryMethodid = await _repositoryManager.OrderHistoryMethodRepository.GetId(orderHistoryMethodCode, cancellationToken);
            var orderHistory = new OrderHistory
            {
                OrderId = orderId,
                OrderHistoryMethodId = orderHistoryMethodid,
                Description = OrderHistoryDescription
            };

            await _repositoryManager.OrderHistoryRepository.Create(orderHistory, cancellationToken);
        }

        private async Task<int> GetOrderStatusId(string orderStatusCode, CancellationToken cancellationToken)
        {
            return await _repositoryManager.OrderStatusRepository.GetIdByCode(orderStatusCode, cancellationToken);
        }

        private async Task<int> GetExecutorStatusId(string executorStatusCode, CancellationToken cancellationToken)
        {
            return await _repositoryManager.ExecutorStatusRepository.GetId(executorStatusCode, cancellationToken);
        }

        private async Task<bool> AllowEdit(int orderStatusId, CancellationToken cancellationToken)
        {
            var orderStatus = await _repositoryManager.OrderStatusRepository.Get(orderStatusId, cancellationToken);
            //TODO: Исправить на Enum
            return orderStatus.Code == "new";
        }
    }
}
