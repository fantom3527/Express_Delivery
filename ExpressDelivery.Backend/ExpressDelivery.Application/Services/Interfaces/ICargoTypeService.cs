using ExpressDelivery.Application.Dto.CargoTypeDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoTypeService
    {
        public Task<IEnumerable<GetCargoTypeDto>> GetAll();
    }
}
