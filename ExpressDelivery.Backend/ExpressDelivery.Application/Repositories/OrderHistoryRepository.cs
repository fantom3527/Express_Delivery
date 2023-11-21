using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public OrderHistoryRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<OrderHistory>> GetAll()
        {
            return await _dbContext.OrderHistory.ToListAsync();
        }

        public async Task<IEnumerable<OrderHistory>> GetAllByOrder(Guid orderId)
        {
            return await _dbContext.OrderHistory.Where(orderHistory => orderHistory.OrderId == orderId).ToListAsync();
        }

        public async Task<OrderHistory> Get(Guid id)
        {
            return await _dbContext.OrderHistory.SingleOrDefaultAsync(orderHistory => orderHistory.Id == id) ?? throw new NotFoundException("OrderHistory not found", id);
        }

        public async Task<Guid> Create(OrderHistory orderHistory)
        {
            await _dbContext.OrderHistory.AddAsync(orderHistory);

            return orderHistory.Id; // TODO: проверить, и подумать, надо ли вообще что-то возвращать
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
