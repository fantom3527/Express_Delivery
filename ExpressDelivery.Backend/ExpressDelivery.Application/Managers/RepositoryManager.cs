using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Managers.Interfaces;
using ExpressDelivery.Application.Repository;
using ExpressDelivery.Application.Repository.Interfaces;

namespace ExpressDelivery.Application.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public RepositoryManager(IExpressDeliveryDbContext dbContext, IExecutorRepository executorRepository)
        {
            _dbContext = dbContext;
            ExecutorRepository = executorRepository;
        }
        public RepositoryManager(IExpressDeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
            ExecutorRepository = new ExecutorRepository(dbContext);
        }
        public IExecutorRepository ExecutorRepository { get; }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
