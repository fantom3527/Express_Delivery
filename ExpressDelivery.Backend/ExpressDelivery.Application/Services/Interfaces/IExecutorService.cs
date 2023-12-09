using ExpressDelivery.Application.Dto.ExecutorDto;

namespace ExpressDelivery.Application.Services.Interfaces
{
    public interface IExecutorService
    {
        public Task<IEnumerable<GetExecutorDto>> GetAll(CancellationToken cancellationToken);
        public Task<GetExecutorDto> Get(Guid id, CancellationToken cancellationToken);
        public Task<Guid> Create(CreateExecutorDto executor, CancellationToken cancellationToken);
        public Task Update(UpdateExecutorDto executor, CancellationToken cancellationToken);
        public Task UpdateStatus(Guid id, int executorStatusId, CancellationToken cancellationToken);
        public Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
