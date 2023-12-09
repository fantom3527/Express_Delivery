using ExpressDelivery.Application.Dto.CargoTypeDto;
using ExpressDelivery.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CargoTypeController : BaseController<ICargoTypeService>
    {
        /// <summary>
        /// Gets all CargoTypes.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /CargoType
        /// </remarks>
        /// <returns>Returns CargoTypes.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCargoTypeDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Service.GetAll(cancellationToken));
        }
    }
}
