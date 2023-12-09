using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class OrderHistoryMethodRepository : IOrderHistoryMethodRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public OrderHistoryMethodRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<OrderHistoryMethod>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderHistoryMethod.ToListAsync(cancellationToken);
        }

        public async Task<OrderHistoryMethod> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.OrderHistoryMethod.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("OrderHistoryMethod not found", id);
        }

        public async Task<int> GetId(string code, CancellationToken cancellationToken = default)
        {
            var orderHistoryMethod = await _dbContext.OrderHistoryMethod.SingleOrDefaultAsync(orderHistoryMethod => orderHistoryMethod.Code == code, cancellationToken);

            return orderHistoryMethod?.Id ?? 0;
        }
    }
}
