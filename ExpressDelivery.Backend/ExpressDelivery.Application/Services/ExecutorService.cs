using AutoMapper;
using ExpressDelivery.Application.Dto.ExecutorDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Services
{
    public class ExecutorService : IExecutorService
    {
        private readonly IExecutorRepository _executorRepository;
        private readonly IMapper _mapper;

        public ExecutorService(IExecutorRepository executorRepository, IMapper mapper) 
            => (_executorRepository, _mapper) = (executorRepository, mapper);

        public async Task<IEnumerable<GetExecutorDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetExecutorDto>>(await _executorRepository.GetAll(cancellationToken));
        }

        public async Task<GetExecutorDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetExecutorDto>(await _executorRepository.Get(id, cancellationToken));
        }

        public async Task<Guid> Create(CreateExecutorDto executor, CancellationToken cancellationToken)
        {
            var id = await _executorRepository.Create(_mapper.Map<Executor>(executor), cancellationToken);
            await _executorRepository.SaveChangesAsync(cancellationToken);

            return id;
        }

        public async Task Update(UpdateExecutorDto executor, CancellationToken cancellationToken)
        {
            await _executorRepository.Update(_mapper.Map<Executor>(executor), cancellationToken);
            await _executorRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStatus(Guid id, int orderStatusId, CancellationToken cancellationToken)
        {
            await _executorRepository.UpdateStatus(id, orderStatusId, cancellationToken);
            await _executorRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _executorRepository.Delete(id, cancellationToken);
            await _executorRepository.SaveChangesAsync(cancellationToken);
        }
    }
}