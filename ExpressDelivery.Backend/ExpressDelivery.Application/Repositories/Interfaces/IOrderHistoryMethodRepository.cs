using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderHistoryMethodRepository
    {
        public Task<IEnumerable<OrderHistoryMethod>> GetAll();
        public Task<OrderHistoryMethod> Get(int id);
        public Task<int> GetId(string code);
    }
}
