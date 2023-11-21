using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Managers.Interfaces;
using ExpressDelivery.Application.Repositories;
using ExpressDelivery.Application.Repositories.Interfaces;

namespace ExpressDelivery.Application.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public RepositoryManager(IExpressDeliveryDbContext dbContext, IExecutorRepository executorRepository, IOrderRepository orderRepository, 
                                 IOrderStatusRepository orderStatusRepository, IExecutorStatusRepository executorStatusRepository, IOrderHistoryRepository orderHistoryRepository,
                                 IOrderHistoryMethodRepository orderHistoryMethodRepository)
        {
            _dbContext = dbContext;
            ExecutorRepository = executorRepository;
            ExecutorStatusRepository = executorStatusRepository;
            OrderRepository = orderRepository;
            OrderStatusRepository = orderStatusRepository;
            OrderHistoryRepository = orderHistoryRepository;
            OrderHistoryMethodRepository = orderHistoryMethodRepository;
            OrderHistoryMethodRepository = orderHistoryMethodRepository;
        }
        public RepositoryManager(IExpressDeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
            ExecutorRepository = new ExecutorRepository(dbContext);
            ExecutorStatusRepository = new ExecutorStatusRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            OrderStatusRepository = new OrderStatusRepository(dbContext);
            OrderHistoryRepository = new OrderHistoryRepository(dbContext);
            OrderHistoryMethodRepository = new OrderHistoryMethodRepository(dbContext);
        }

        public IExecutorRepository ExecutorRepository { get; }
        public IExecutorStatusRepository ExecutorStatusRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderStatusRepository OrderStatusRepository { get; }
        public IOrderHistoryRepository OrderHistoryRepository { get; }
        public IOrderHistoryMethodRepository OrderHistoryMethodRepository { get; }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}