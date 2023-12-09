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

        public async Task<IEnumerable<OrderStatus>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderStatus.ToListAsync(cancellationToken);
        }

        public async Task<OrderStatus> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderStatus.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("OrderStatus not found", id);
        }

        public async Task<int> GetIdByCode(string code, CancellationToken cancellationToken = default)
        {
            var orderStatus = await _dbContext.OrderStatus.SingleOrDefaultAsync(orderStatus => orderStatus.Code == code, cancellationToken);

            return orderStatus?.Id ?? 0;
        }
    }
}
