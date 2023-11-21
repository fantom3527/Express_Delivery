using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IExecutorRepository
    {
        public Task<IEnumerable<Executor>> GetAll();
        public Task<Executor> Get(Guid id);
        public Task<Guid> Create(Executor executor);
        public Task Update(Executor executor);
        public Task UpdateStatus(Guid id, int executorStatus);
        public Task Delete(Guid id);

        public Task SaveChangesAsync();
    }
}
