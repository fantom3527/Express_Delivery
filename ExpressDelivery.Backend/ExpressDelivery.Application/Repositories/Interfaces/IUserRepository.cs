using ExpressDelivery.Domain;
using System.Threading;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default);
        public Task<User> Get(Guid id, CancellationToken cancellationToken = default);
    }
}
