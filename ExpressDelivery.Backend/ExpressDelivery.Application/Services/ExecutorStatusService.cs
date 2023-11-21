using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class ExecutorStatusService : IExecutorStatusService
    {
        private readonly IExecutorStatusRepository _executorStatusRepository;

        public ExecutorStatusService(IExecutorStatusRepository executorStatusRepository)
            => _executorStatusRepository = executorStatusRepository;
        public async Task<IEnumerable<ExecutorStatus>> GetAll()
        {
            return await _executorStatusRepository.GetAll();
        }
    }
}
