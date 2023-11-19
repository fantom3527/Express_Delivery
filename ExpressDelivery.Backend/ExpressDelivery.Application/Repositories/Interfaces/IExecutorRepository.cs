using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repository.Interfaces
{
    public interface IExecutorRepository
    {
        public Task<IEnumerable<Executor>> GetAll();
        public Task<Executor> Get(Guid id);
        public Task<Guid> Create(Executor executor);
        public Task Update(Executor executor);
        public Task Delete(Guid id);

        public Task SaveChangesAsync();
    }
}
