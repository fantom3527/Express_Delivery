using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Dto.ExecutorDto;
using ExpressDelivery.Application.Services.Interfaces;
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
        /// <summary>
        /// Gets all Executors.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /Executor
        /// </remarks>
        /// <returns>Returns Executors.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetExecutorDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Service.GetAll(cancellationToken));
        }

        /// <summary>
        /// Gets Executor by id.
        /// </summary>
        /// <param name="id">Executor id (guid).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /Executor/A8D8532E-9DAA-4451-BE64-CC760E6A815C
        /// </remarks>
        /// <returns>Returns Executor.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetExecutorDto>> Get([Required] Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Service.Get(id, cancellationToken));
        }

        /// <summary>
        /// Creates the Executor.
        /// </summary>
        /// <param name="createExecutorDto">CreateExecutorDto object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// POST /Executor
        /// {
        ///     name: "Executor name"
        ///     description: "Executor description"
        ///     ExecutorStatusId: "1"
        /// }
        /// </remarks>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([Required] CreateExecutorDto createExecutorDto, CancellationToken cancellationToken)
        {
            return Ok(await Service.Create(createExecutorDto, cancellationToken));
        }

        /// <summary>
        /// Updates the Executor.
        /// </summary>
        /// <param name="updateExecutorDto">UpdateExecutorDto object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// Sample request:
        /// <remarks>
        /// PUT /Executor
        /// {
        ///     id: "A8D8532E-9DAA-4451-BE64-CC760E6A815C"
        ///     name: "Executor name"
        ///     description: "Executor description"
        /// }
        /// </remarks>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody][Required] UpdateExecutorDto updateExecutorDto, CancellationToken cancellationToken)
        {
            await Service.Update(updateExecutorDto, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Changes status the Executor.
        /// </summary>
        /// <param name="id">Executor id.</param>
        /// <param name="executorStatusId">Executor status id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// Sample request:
        /// <remarks>
        /// PUT /Executor/status
        /// {
        ///     id: "A8D8532E-9DAA-4451-BE64-CC760E6A815C"
        ///     executorStatusId: "Executor status id"
        /// }
        /// </remarks>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatus([FromQuery][Required] Guid id, [FromQuery][Required] int executorStatusId, CancellationToken cancellationToken)
        {
            await Service.UpdateStatus(id, executorStatusId, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Deletes the Executor by id.
        /// </summary>
        /// <param name="id">Executor id (guid).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// DELETE /Executor/A8D8532E-9DAA-4451-BE64-CC760E6A815C
        /// </remarks>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([Required] Guid id, CancellationToken cancellationToken)
        {
            await Service.Delete(id, cancellationToken);

            return NoContent();
        }
    }
}
