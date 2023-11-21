using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public OrderStatusRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _dbContext.OrderStatus.ToListAsync();
        }

        public async Task<OrderStatus> Get(int id)
        {
            return await _dbContext.OrderStatus.SingleOrDefaultAsync(orderStatus => orderStatus.Id == id) ?? throw new NotFoundException("OrderStatus not found", id);
        }

        public async Task<int> GetId(string code)
        {
            var orderStatus = await _dbContext.OrderStatus.SingleOrDefaultAsync(orderStatus => orderStatus.Code == code);

            return orderStatus?.Id ?? 0;
        }
    }
}
