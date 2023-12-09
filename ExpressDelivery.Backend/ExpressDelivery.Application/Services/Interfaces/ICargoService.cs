using ExpressDelivery.Application.Dto.CargoDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<GetCargoDto>> GetAll(CancellationToken cancellationToken);
        public Task<GetCargoDto> Get(Guid id, CancellationToken cancellationToken);
        public Task AddOrder(Guid id, Guid orderId, CancellationToken cancellationToken);
    }
}
