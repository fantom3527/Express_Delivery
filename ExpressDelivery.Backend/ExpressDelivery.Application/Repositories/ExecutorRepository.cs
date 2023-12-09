using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class ExecutorRepository : IExecutorRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public ExecutorRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<Executor>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Executor.ToListAsync(cancellationToken);
        }

        public async Task<Executor> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Executor.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Executor not found", id);
        }

        public async Task<Guid> Create(Executor executor, CancellationToken cancellationToken = default)
        {
            await _dbContext.Executor.AddAsync(executor, cancellationToken);

            return executor.Id; // TODO: проверить, и подумать, надо ли вообще что-то возвращать
        }

        public async Task Update(Executor executor, CancellationToken cancellationToken = default)
        {
            var executorToUpdate = await _dbContext.Executor.FindAsync(new object[] { executor.Id }, cancellationToken) ?? throw new NotFoundException("Executor not found", executor.Id);
            if (executorToUpdate != null)
            {
                executorToUpdate.Name = executor.Name;
                executorToUpdate.Description = executor.Description;
                executorToUpdate.ExecutorStatusId = executor.ExecutorStatusId;
            }
        }

        public async Task UpdateStatus(Guid id, int executorStatusId, CancellationToken cancellationToken = default)
        {
            var executorToUpdateStatus = await _dbContext.Executor.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Executor not found", id);
            if (executorToUpdateStatus == null)
                return;

            executorToUpdateStatus.ExecutorStatusId = executorStatusId;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var executorToDelete = await _dbContext.Executor.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Executor not found", id);
            if (executorToDelete != null)
            {
                _dbContext.Executor.Remove(executorToDelete);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
