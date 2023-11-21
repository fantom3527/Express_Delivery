using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class CargoTypeRepository : ICargoTypeRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public CargoTypeRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<CargoType>> GetAll()
        {
            return await _dbContext.CargoType.ToListAsync();
        }
    }
}
