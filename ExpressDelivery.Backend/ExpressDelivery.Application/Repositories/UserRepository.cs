using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public UserRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(user => user.Id == id) ?? throw new NotFoundException("user not found", id);
        }
    }
}
