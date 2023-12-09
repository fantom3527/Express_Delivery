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

        public async Task<IEnumerable<Cargo>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Cargo.ToListAsync(cancellationToken);
        }

        public async Task<Cargo> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Cargo.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Cargo not found", id);
        }

        public async Task AddOrder(Guid id, Guid orderId, CancellationToken cancellationToken = default)
        {
            var addOrderToExecuter = await _dbContext.Cargo.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Cargo not found", id); ;

            if (addOrderToExecuter == null)
                return;

            addOrderToExecuter.OrderId = orderId;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
