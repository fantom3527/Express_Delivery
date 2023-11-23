using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderHistoryController : BaseController<IOrderHistoryService>
    {
        /// <summary>
        /// Gets all OrderHistories.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /OrderHistory
        /// </remarks>
        /// <returns>Returns OrderHistories.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        //TODO: Добавить из тестового актуальный id

        /// <summary>
        /// Gets OrderHistories by id.
        /// </summary>
        /// <param name="orderId">Order id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /OrderHistory/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns OrderHistories.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllByOrder(Guid orderId)
        {
            return Ok(await Service.GetAllByOrder(orderId));
        }
    }
}
