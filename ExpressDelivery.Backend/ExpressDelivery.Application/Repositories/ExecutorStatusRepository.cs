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

        public async Task<IEnumerable<ExecutorStatus>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.ExecutorStatus.ToListAsync(cancellationToken);
        }

        public async Task<ExecutorStatus> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.ExecutorStatus.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("ExecutorStatus not found", id);
        }

        public async Task<int> GetId(string code, CancellationToken cancellationToken = default)
        {
            var executorStatus = await _dbContext.ExecutorStatus.SingleOrDefaultAsync(executorStatus => executorStatus.Code == code, cancellationToken);

            return executorStatus?.Id ?? 0;
        }
    }
}
