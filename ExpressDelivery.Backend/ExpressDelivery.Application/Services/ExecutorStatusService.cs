using AutoMapper;
using ExpressDelivery.Application.Dto.ExecutorStatusDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class ExecutorStatusService : IExecutorStatusService
    {
        private readonly IExecutorStatusRepository _executorStatusRepository;
        private readonly IMapper _mapper;

        public ExecutorStatusService(IExecutorStatusRepository executorStatusRepository, IMapper mapper)
            => (_executorStatusRepository, _mapper) = (executorStatusRepository, mapper);

        public async Task<IEnumerable<GetExecutorStatusDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetExecutorStatusDto>>(await _executorStatusRepository.GetAll(cancellationToken));
        }
    }
}
