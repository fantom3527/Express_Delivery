using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderHistoryMethodController : BaseController<IOrderHistoryMethodService>
    {
        /// <summary>
        /// Gets all OrderHistoryMethods.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /OrderHistoryMethod
        /// </remarks>
        /// <returns>Returns OrderHistoryMethods.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderHistoryMethod>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }
    }
}
