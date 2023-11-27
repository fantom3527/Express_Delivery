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

        /// <summary>
        /// Gets all Executors.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Executor
        /// </remarks>
        /// <returns>Returns Executors.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Executor>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        //TODO: Сделать актуалочку данных.

        /// <summary>
        /// Gets Executor by id.
        /// </summary>
        /// <param name="id">Executor id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Executor/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns Executor.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Executor>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }

        /// <summary>
        /// Creates the Executor.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /Executor
        /// {
        ///     name: "Executor name"
        ///     description: "Executor description"
        ///     ExecutorStatusId: "1"
        /// }
        /// </remarks>
        /// <param name="createExecutorDto">CreateExecutorDto object.</param>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create(CreateExecutorDto createExecutorDto)
        {
            var command = _mapper.Map<Executor>(createExecutorDto);
            return Ok(await Service.Create(command));
        }

        /// <summary>
        /// Updates the Executor.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Executor
        /// {
        ///     id: "Executor id"
        ///     name: "Executor name"
        ///     description: "Executor description"
        /// }
        /// </remarks>
        /// <param name="updateExecutorDto">UpdateExecutorDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateExecutorDto updateExecutorDto)
        {
            var command = _mapper.Map<Executor>(updateExecutorDto);
            await Service.Update(command);

            return NoContent();
        }

        /// <summary>
        /// Changes status the Executor.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Executor/status
        /// {
        ///     id: "Executor id"
        ///     executorStatusId: "Executor status id"
        /// }
        /// </remarks>
        /// <param name="id">Executor id.</param>
        /// <param name="executorStatusId">Executor status id.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatus([FromQuery] Guid id, [FromQuery] int executorStatusId)
        {
            await Service.UpdateStatus(id, executorStatusId);

            return NoContent();
        }

        /// <summary>
        /// Deletes the Executor by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Executor/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Executor id (guid).</param>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Service.Delete(id);

            return NoContent();
        }
    }
}
