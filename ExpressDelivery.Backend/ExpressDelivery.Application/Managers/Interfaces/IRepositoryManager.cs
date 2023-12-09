using ExpressDelivery.Application.Repositories.Interfaces;

namespace ExpressDelivery.Application.Managers.Interfaces
{
    public interface IRepositoryManager
    {
        public IExecutorRepository ExecutorRepository { get; }
        public IExecutorStatusRepository ExecutorStatusRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderStatusRepository OrderStatusRepository { get; }
        public IOrderHistoryRepository OrderHistoryRepository { get; }
        public IOrderHistoryMethodRepository OrderHistoryMethodRepository { get; }

        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
