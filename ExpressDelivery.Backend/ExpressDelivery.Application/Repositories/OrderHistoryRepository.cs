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

        public async Task<IEnumerable<OrderHistory>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderHistory.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderHistory>> GetAllByOrder(Guid orderId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderHistory.Where(orderHistory => orderHistory.OrderId == orderId).ToListAsync(cancellationToken);
        }

        public async Task<OrderHistory> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderHistory.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("OrderHistory not found", id);
        }

        public async Task<Guid> Create(OrderHistory orderHistory, CancellationToken cancellationToken = default)
        {
            await _dbContext.OrderHistory.AddAsync(orderHistory, cancellationToken);

            return orderHistory.Id; // TODO: проверить, и подумать, надо ли вообще что-то возвращать
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
