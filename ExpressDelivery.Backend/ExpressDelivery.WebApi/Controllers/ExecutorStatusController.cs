using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ExecutorStatusController : BaseController<IExecutorStatusService>
    {
        /// <summary>
        /// Gets all ExecutorStatuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /ExecutorStatus
        /// </remarks>
        /// <returns>Returns ExecutorStatuses.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExecutorStatus>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }
    }
}
