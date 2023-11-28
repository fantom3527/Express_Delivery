using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public CargoRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _dbContext.Cargo.ToListAsync();
        }

        public async Task<Cargo> Get(Guid id)
        {
            return await _dbContext.Cargo.FindAsync(id) ?? throw new NotFoundException("Cargo not found", id);
        }

        public async Task AddOrder(Guid id, Guid orderId)
        {
            var addOrderToExecuter = await _dbContext.Cargo.FindAsync(id);

            if (addOrderToExecuter == null)
                return;

            addOrderToExecuter.OrderId = orderId;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
