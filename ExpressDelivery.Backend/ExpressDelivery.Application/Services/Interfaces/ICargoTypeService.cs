using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface ICargoTypeService
    {
        public Task<IEnumerable<CargoType>> GetAll();
    }
}
