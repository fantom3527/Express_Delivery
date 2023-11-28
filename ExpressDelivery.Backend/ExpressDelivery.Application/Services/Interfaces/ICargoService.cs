using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<Cargo>> GetAll();
        public Task<Cargo> Get(Guid id);
        public Task AddOrder(Guid id, Guid orderId);
    }
}
