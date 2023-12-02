using ExpressDelivery.Application.Dto.ExecutorDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IExecutorService
    {
        public Task<IEnumerable<GetExecutorDto>> GetAll();
        public Task<GetExecutorDto> Get(Guid id);
        public Task<Guid> Create(CreateExecutorDto executor);
        public Task Update(UpdateExecutorDto executor);
        public Task UpdateStatus(Guid id, int executorStatusId);
        public Task Delete(Guid id);
    }
}
