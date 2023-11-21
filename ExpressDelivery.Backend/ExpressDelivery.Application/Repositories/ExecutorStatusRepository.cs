using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class ExecutorStatusRepository : IExecutorStatusRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public ExecutorStatusRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<ExecutorStatus>> GetAll()
        {
            return await _dbContext.ExecutorStatus.ToListAsync();
        }

        public async Task<ExecutorStatus> Get(int id)
        {
            return await _dbContext.ExecutorStatus.SingleOrDefaultAsync(executorStatus => executorStatus.Id == id) ?? throw new NotFoundException("Order not found", id);
        }

        public async Task<int> GetId(string code)
        {
            var executorStatus = await _dbContext.ExecutorStatus.SingleOrDefaultAsync(executorStatus => executorStatus.Code == code);

            return executorStatus?.Id ?? 0;
        }
    }
}
