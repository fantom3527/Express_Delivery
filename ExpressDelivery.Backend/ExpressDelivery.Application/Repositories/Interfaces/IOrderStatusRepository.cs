using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderStatusRepository
    {
        public Task<IEnumerable<OrderStatus>> GetAll(CancellationToken cancellationToken = default);
        public Task<OrderStatus> Get(int id, CancellationToken cancellationToken = default);
        public Task<int> GetIdByCode(string code, CancellationToken cancellationToken = default);
    }
}
