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

        public async Task<IEnumerable<GetExecutorDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GetExecutorDto>>(await _executorRepository.GetAll());
        }

        public async Task<GetExecutorDto> Get(Guid id)
        {
            return _mapper.Map<GetExecutorDto>(await _executorRepository.Get(id));
        }

        public async Task<Guid> Create(CreateExecutorDto executor)
        {
            var id = await _executorRepository.Create(_mapper.Map<Executor>(executor));
            await _executorRepository.SaveChangesAsync();

            return id;
        }

        public async Task Update(UpdateExecutorDto executor)
        {
            await _executorRepository.Update(_mapper.Map<Executor>(executor));
            await _executorRepository.SaveChangesAsync();
        }

        public async Task UpdateStatus(Guid id, int orderStatusId)
        {
            await _executorRepository.UpdateStatus(id, orderStatusId);
            await _executorRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _executorRepository.Delete(id);
            await _executorRepository.SaveChangesAsync();
        }
    }
}