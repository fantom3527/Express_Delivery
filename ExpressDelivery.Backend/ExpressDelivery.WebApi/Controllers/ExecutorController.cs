using AutoMapper;
using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Dto.ExecutorDto;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Gets Executor by id.
        /// </summary>
        /// <param name="id">Executor id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Executor/A8D8532E-9DAA-4451-BE64-CC760E6A815C
        /// </remarks>
        /// <returns>Returns Executor.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Executor>> Get([Required] Guid id)
        {
            try
            {
                return Ok(await Service.Get(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
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
        public async Task<ActionResult<Guid>> Create([Required] CreateExecutorDto createExecutorDto)
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
        ///     id: "A8D8532E-9DAA-4451-BE64-CC760E6A815C"
        ///     name: "Executor name"
        ///     description: "Executor description"
        /// }
        /// </remarks>
        /// <param name="updateExecutorDto">UpdateExecutorDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody][Required] UpdateExecutorDto updateExecutorDto)
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
        ///     id: "A8D8532E-9DAA-4451-BE64-CC760E6A815C"
        ///     executorStatusId: "Executor status id"
        /// }
        /// </remarks>
        /// <param name="id">Executor id.</param>
        /// <param name="executorStatusId">Executor status id.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatus([FromQuery][Required] Guid id, [FromQuery][Required] int executorStatusId)
        {
            await Service.UpdateStatus(id, executorStatusId);

            return NoContent();
        }

        /// <summary>
        /// Deletes the Executor by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Executor/A8D8532E-9DAA-4451-BE64-CC760E6A815C
        /// </remarks>
        /// <param name="id">Executor id (guid).</param>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([Required] Guid id)
        {
            await Service.Delete(id);

            return NoContent();
        }
    }
}
