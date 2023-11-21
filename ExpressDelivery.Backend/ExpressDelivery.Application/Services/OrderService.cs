using ExpressDelivery.Application.Managers.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderService(IRepositoryManager repositoryManager)
            => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _repositoryManager.OrderRepository.GetAll();
        }
        public async Task<Order> Get(Guid id)
        {
            return await _repositoryManager.OrderRepository.Get(id);
        }

        public async Task<IEnumerable<Order>> GetQuery(string queryText)
        {
            return await _repositoryManager.OrderRepository.GetQuery(queryText);
        }

        public async Task<Guid> Create(Order order)
        {
            await CreateOrder(order);
            //TODO: Исправить на Enum
            await CreateOrderHistory(order.Id, "create");
            await _repositoryManager.SaveChangesAsync();

            return order.Id;
        }

        public async Task Update(Order order)
        {
            // TODO: Реализация пробрасывания своего исключения, если статус при обновлении данных не новый.
            if (!(await AllowEdit(order.OrderStatusId)))
                return;

            await _repositoryManager.OrderRepository.Update(order);
            //TODO: Исправить на Enum
            await CreateOrderHistory(order.Id, "edit");
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus)
        {
            await _repositoryManager.OrderRepository.UpdateStatus(id, orderStatusId);
            // TODO: Проверить как будет без описание и с описанием.
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

        public async Task AssignmentExecutor(Guid orderId, Guid executorId)
        {
            await _repositoryManager.OrderRepository.AssignmentExecutor(orderId, executorId);
            //TODO: Исправить на Enum
            await _repositoryManager.OrderRepository.UpdateStatus(orderId, await GetOrderStatusId("submitted"));
            await _repositoryManager.ExecutorRepository.UpdateStatus(executorId, await GetExecutorStatusId("executesorder"));
            await CreateOrderHistory(orderId, "assignmentexecutor");
            await _repositoryManager.SaveChangesAsync();
        }

        private async Task CreateOrder(Order order)
        {
            order.OrderStatusId = await GetOrderStatusId("new");
            await _repositoryManager.OrderRepository.Create(order);
        }

        //TODO: Добавить добавление поля, кто сделал изменения: Исполнитель, заказчик или система (Их Id).
        private async Task CreateOrderHistory(Guid orderId, string orderHistoryMethodCode, string OrderHistoryDescription = "")
        {
            //TODO: Добавить проверку, если нет в списке нужных методов по коду
            int orderHistoryMethodid = await _repositoryManager.OrderHistoryMethodRepository.GetId(orderHistoryMethodCode);
            var orderHistory = new OrderHistory
            {
                Id = orderId,
                OrderHistoryMethodId = orderHistoryMethodid,
                Description = OrderHistoryDescription
            };

            await _repositoryManager.OrderHistoryRepository.Create(orderHistory);
        }

        private async Task<int> GetOrderStatusId(string orderStatusCode)
        {
            return await _repositoryManager.OrderStatusRepository.GetId(orderStatusCode);
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
