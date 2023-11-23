using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<Cargo>> GetAll();
        public Task<Cargo> Get(Guid id);
    }
}
