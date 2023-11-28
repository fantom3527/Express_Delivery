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

        public async Task<IEnumerable<Executor>> GetAll()
        {
            return await _dbContext.Executor.ToListAsync();
        }

        public async Task<Executor> Get(Guid id)
        {
            return await _dbContext.Executor.FindAsync(id) ?? throw new NotFoundException("Executor not found", id);
        }

        public async Task<Guid> Create(Executor executor)
        {
            await _dbContext.Executor.AddAsync(executor);

            return executor.Id; // TODO: проверить, и подумать, надо ли вообще что-то возвращать
        }

        public async Task Update(Executor executor)
        {
            var executorToUpdate = await _dbContext.Executor.FindAsync(executor.Id);
            if (executorToUpdate != null)
            {
                executorToUpdate.Name = executor.Name;
                executorToUpdate.Description = executor.Description;
                executorToUpdate.ExecutorStatusId = executor.ExecutorStatusId;
            }
        }

        public async Task UpdateStatus(Guid id, int executorStatus)
        {
            var executorToUpdateStatus = await _dbContext.Executor.FindAsync(id);
            if (executorToUpdateStatus == null)
                return;

            executorToUpdateStatus.ExecutorStatusId = executorStatus;
        }

        public async Task Delete(Guid id)
        {
            var executorToDelete = await _dbContext.Executor.FindAsync(id);
            if (executorToDelete != null)
            {
                _dbContext.Executor.Remove(executorToDelete);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
