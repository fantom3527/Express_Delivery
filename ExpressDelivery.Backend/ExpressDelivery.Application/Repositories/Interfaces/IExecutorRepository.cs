using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IExecutorRepository
    {
        public Task<IEnumerable<Executor>> GetAll(CancellationToken cancellationToken = default);
        public Task<Executor> Get(Guid id, CancellationToken cancellationToken = default);
        public Task<Guid> Create(Executor executor, CancellationToken cancellationToken = default);
        public Task Update(Executor executor, CancellationToken cancellationToken = default);
        public Task UpdateStatus(Guid id, int executorStatus, CancellationToken cancellationToken = default);
        public Task Delete(Guid id, CancellationToken cancellationToken = default);

        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
