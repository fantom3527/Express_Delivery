using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repository.Interfaces;

namespace ExpressDelivery.Application.Managers.Interfaces
{
    public interface IRepositoryManager
    {
        public IExecutorRepository ExecutorRepository { get; }

        public Task SaveChangesAsync();
    }
}
