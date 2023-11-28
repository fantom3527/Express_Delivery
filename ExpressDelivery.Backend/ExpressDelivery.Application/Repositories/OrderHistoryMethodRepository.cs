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

        public async Task<IEnumerable<OrderHistoryMethod>> GetAll()
        {
            return await _dbContext.OrderHistoryMethod.ToListAsync();
        }

        public async Task<OrderHistoryMethod> Get(int id)
        {
            return await _dbContext.OrderHistoryMethod.FindAsync(id) ?? throw new NotFoundException("OrderHistoryMethod not found", id);
        }

        public async Task<int> GetId(string code)
        {
            var orderHistoryMethod = await _dbContext.OrderHistoryMethod.SingleOrDefaultAsync(orderHistoryMethod => orderHistoryMethod.Code == code);

            return orderHistoryMethod?.Id ?? 0;
        }
    }
}
