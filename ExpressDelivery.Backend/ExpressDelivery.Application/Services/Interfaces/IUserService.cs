using ExpressDelivery.Application.Dto.UserDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<GetUserDto>> GetAll(CancellationToken cancellationToken);
        public Task<GetUserDto> Get(Guid id, CancellationToken cancellationToken);
    }
}
