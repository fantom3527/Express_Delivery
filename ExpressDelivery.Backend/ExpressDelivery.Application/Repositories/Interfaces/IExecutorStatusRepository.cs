using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IExecutorStatusRepository
    {
        public Task<IEnumerable<ExecutorStatus>> GetAll(CancellationToken cancellationToken = default);
        public Task<ExecutorStatus> Get(int id, CancellationToken cancellationToken = default);
        public Task<int> GetId(string code, CancellationToken cancellationToken = default);
    }
}
