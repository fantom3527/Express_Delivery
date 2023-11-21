using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IExecutorStatusRepository
    {
        public Task<IEnumerable<ExecutorStatus>> GetAll();
        public Task<ExecutorStatus> Get(int id);
        public Task<int> GetId(string code);
    }
}
