using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IExecutorService
    {
        public Task<IEnumerable<Executor>> GetAll();
        public Task<Executor> Get(Guid id);
        public Task<Guid> Create(Executor executor);
        public Task Delete(Guid id);
        public Task Update(Executor executor);
    }
}
