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

        public async Task<IEnumerable<GetOrderDto>> GetAll()
        {
            var orders = await _repositoryManager.OrderRepository.GetAll();

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }
        public async Task<GetOrderDto> Get(Guid id)
        {
            return _mapper.Map<GetOrderDto>(await _repositoryManager.OrderRepository.Get(id));
        }

        public async Task<IEnumerable<GetOrderDto>> GetQuery(string queryText)
        {
            var orders = await _repositoryManager.OrderRepository.GetQuery(queryText);

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }

        public async Task<Guid> Create(CreateOrderDto order)
        {
            Guid id = await CreateOrder(_mapper.Map<Order>(order));
            //TODO: Исправить на Enum
            await CreateOrderHistory(id, "create");
            await _repositoryManager.SaveChangesAsync();

            return id;
        }

        public async Task Update(UpdateOrderDto order)
        {
            // TODO: Реализация пробрасывания своего исключения, если статус при обновлении данных не новый.
            if (!await AllowEdit(order.OrderStatusId))
                return;

            await _repositoryManager.OrderRepository.Update(_mapper.Map<Order>(order));
            //TODO: Исправить на Enum
            await CreateOrderHistory(order.Id, "edit");
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus)
        {
            await _repositoryManager.OrderRepository.UpdateStatus(id, orderStatusId);
            //TODO: Исправить на Enum
            await CreateOrderHistory(id, "updatestatus", descriptionUpdateStatus);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            //TODO: Исправить на Enum
            await _repositoryManager.OrderRepository.Delete(id, await GetOrderStatusId("deleted"));
            await CreateOrderHistory(id, "delete");
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task AddExecutor(Guid orderId, Guid executorId)
        {
            await _repositoryManager.OrderRepository.AddExecutor(orderId, executorId);
            //TODO: Исправить на Enum
            await _repositoryManager.OrderRepository.UpdateStatus(orderId, await GetOrderStatusId("submitted"));
            await _repositoryManager.ExecutorRepository.UpdateStatus(executorId, await GetExecutorStatusId("executesorder"));
            await CreateOrderHistory(orderId, "submittedexecution");
            await _repositoryManager.SaveChangesAsync();
        }

        private async Task<Guid> CreateOrder(Order order)
        {
            order.OrderStatusId = await GetOrderStatusId("new");

            return await _repositoryManager.OrderRepository.Create(order);
        }

        //TODO: Добавить добавление поля, кто сделал изменения: Исполнитель, заказчик или система (Их Id).
        private async Task CreateOrderHistory(Guid orderId, string orderHistoryMethodCode, string OrderHistoryDescription = null)
        {
            //TODO: Добавить проверку, если нет в списке нужных методов по коду
            int orderHistoryMethodid = await _repositoryManager.OrderHistoryMethodRepository.GetId(orderHistoryMethodCode);
            var orderHistory = new OrderHistory
            {
                OrderId = orderId,
                OrderHistoryMethodId = orderHistoryMethodid,
                Description = OrderHistoryDescription
            };

            await _repositoryManager.OrderHistoryRepository.Create(orderHistory);
        }

        private async Task<int> GetOrderStatusId(string orderStatusCode)
        {
            return await _repositoryManager.OrderStatusRepository.GetIdByCode(orderStatusCode);
        }

        private async Task<int> GetExecutorStatusId(string executorStatusCode)
        {
            return await _repositoryManager.ExecutorStatusRepository.GetId(executorStatusCode);
        }

        private async Task<bool> AllowEdit(int orderStatusId)
        {
            var orderStatus = await _repositoryManager.OrderStatusRepository.Get(orderStatusId);
            //TODO: Исправить на Enum
            return orderStatus.Code == "new";
        }
    }
}
