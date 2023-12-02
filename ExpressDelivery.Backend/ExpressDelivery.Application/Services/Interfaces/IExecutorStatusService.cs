using ExpressDelivery.Application.Dto.ExecutorStatusDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IExecutorStatusService
    {
        public Task<IEnumerable<GetExecutorStatusDto>> GetAll();
    }
}
