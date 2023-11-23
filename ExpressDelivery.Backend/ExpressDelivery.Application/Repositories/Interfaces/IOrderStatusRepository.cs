using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Repositories.Interfaces
{
    public interface IOrderStatusRepository
    {
        public Task<IEnumerable<OrderStatus>> GetAll();
        public Task<OrderStatus> Get(int id);
        public Task<int> GetIdByCode(string code);
    }
}
