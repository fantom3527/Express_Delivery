using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IExecutorStatusService
    {
        public Task<IEnumerable<ExecutorStatus>> GetAll();
    }
}
