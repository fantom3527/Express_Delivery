using ExpressDelivery.Application.Dto.CargoDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<IEnumerable<GetCargoDto>> GetAll();
        public Task<GetCargoDto> Get(Guid id);
        public Task AddOrder(Guid id, Guid orderId);
    }
}
