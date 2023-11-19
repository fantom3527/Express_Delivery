using ExpressDelivery.Application.Repository.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class ExecutorService : IExecutorService
    {
        private readonly IExecutorRepository _executorRepository;

        public ExecutorService(IExecutorRepository executorRepository) 
            => _executorRepository = executorRepository;
        public async Task<IEnumerable<Executor>> GetAll()
        {
            return await _executorRepository.GetAll();
        }
        public async Task<Executor> Get(Guid id)
        {
            return await _executorRepository.Get(id);
        }
        public async Task<Guid> Create(Executor executor)
        {
            var id = await _executorRepository.Create(executor);
            await _executorRepository.SaveChangesAsync();

            return id;
        }
        public async Task Update(Executor executor)
        {
            await _executorRepository.Update(executor);
            await _executorRepository.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            await _executorRepository.Delete(id);
            await _executorRepository.SaveChangesAsync();
        }
    }
}