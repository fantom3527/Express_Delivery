using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Get(Guid id);
    }
}
