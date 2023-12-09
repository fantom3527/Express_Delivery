using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderHistoryMethodRepository
    {
        public Task<IEnumerable<OrderHistoryMethod>> GetAll(CancellationToken cancellationToken = default);
        public Task<OrderHistoryMethod> Get(int id, CancellationToken cancellationToken = default);
        public Task<int> GetId(string code, CancellationToken cancellationToken = default);
    }
}
