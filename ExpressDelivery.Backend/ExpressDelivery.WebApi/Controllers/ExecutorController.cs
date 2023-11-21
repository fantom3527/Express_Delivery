using AutoMapper;
using ExpressDelivery.Application.Dto.ExecutorDto;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ExecutorController : BaseController<IExecutorService>
    {
        private readonly IMapper _mapper;
        public ExecutorController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Executor>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Executor>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateExecutorDto createExecutorDto)
        {
            var command = _mapper.Map<Executor>(createExecutorDto);
            return Ok(await Service.Create(command));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateExecutorDto updateExecutorDto)
        {
            var command = _mapper.Map<Executor>(updateExecutorDto);
            await Service.Update(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Service.Delete(id);

            return NoContent();
        }
    }
}
