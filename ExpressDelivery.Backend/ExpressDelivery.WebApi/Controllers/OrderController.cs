using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Dto.OrderDto;
using ExpressDelivery.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderController : BaseController<IOrderService>
    {
        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /Order
        /// </remarks>
        /// <returns>Returns Orders.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Service.GetAll(cancellationToken));
        }

        /// <summary>
        /// Gets Order by id.
        /// </summary>
        /// <param name="id">Order id (guid).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /Order/A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568
        /// </remarks>
        /// <returns>Returns Order.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetOrderDto>> Get([Required] Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Service.Get(id, cancellationToken));
        }

        /// <summary>
        /// Gets Order by query.
        /// </summary>
        /// <param name="queryText">query Text (string).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /Order/query-text/new
        /// </remarks>
        /// <returns>Returns Order.</returns>
        /// <response code="200">Success</response>
        [HttpGet("query-text/{queryText}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetQuery([Required] string queryText, CancellationToken cancellationToken)
        {
            return Ok(await Service.GetQuery(queryText, cancellationToken));
        }

        /// <summary>
        /// Creates the Order.
        /// </summary>
        /// <param name="createOrderDto">CreateOrderDto object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// POST /Order
        /// {
        ///     name: "Order name"
        ///     userId: "7EEF1949-580D-4F67-B754-EC74CA91D836"
        ///     receiptAddress: "Komarovo"
        ///     deliveryAddress: "Moscow"
        ///     receiptTime: "10.10.2023" 
        ///     deliveryTime: "20.10.2023"
        ///     description: "Order description"
        /// }
        /// </remarks>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([Required] CreateOrderDto createOrderDto, CancellationToken cancellationToken)
        {
            return Ok(await Service.Create(createOrderDto, cancellationToken));
        }

        /// <summary>
        /// Updates the Order.
        /// </summary>
        /// <param name="updateOrderDto">UpdateOrderDto object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// Sample request:
        /// <remarks>
        /// PUT /Order
        /// {
        ///     id: "A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"
        ///     name: "Order name"
        ///     receiptAddress: "Novosibirsk"
        ///     deliveryAddress: "Moscow"
        ///     receiptTime: "12.10.2023" 
        ///     deliveryTime: "23.10.2023"
        ///     description: "Order description"
        /// }
        /// </remarks>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody][Required] UpdateOrderDto updateOrderDto, CancellationToken cancellationToken)
        {
            await Service.Update(updateOrderDto, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Changes status the Order.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <param name="orderStatusId">Order status id.</param>
        /// <param name="descriptionUpdateStatus">Description update Status for order history.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// Sample request:
        /// <remarks>
        /// PUT /Order/status
        /// {
        ///     id: "8CC409BF-33EA-4FD5-8952-28EC247D4C4B"
        ///     orderStatusId: "Order status id"
        ///     descriptionUpdateStatus: "Description Update Status"
        /// }
        /// </remarks>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatus([FromQuery][Required] Guid id, [FromQuery][Required] int orderStatusId, CancellationToken cancellationToken, [FromQuery] string? descriptionUpdateStatus = null)
        {
            await Service.UpdateStatus(id, orderStatusId, descriptionUpdateStatus, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Add Executor to Order".
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <param name="executorId">Executor id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// Sample request:
        /// <remarks>
        /// PUT /Order/add-executor
        /// {
        ///     id: "8CC409BF-33EA-4FD5-8952-28EC247D4C4B"
        ///     executorId: "A56E0344-8120-4543-91D0-0726CA1DF416"
        /// }
        /// </remarks>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("add-executor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddExecutor([FromQuery][Required] Guid id, [FromQuery][Required] Guid executorId, CancellationToken cancellationToken)
        {
            await Service.AddExecutor(id, executorId, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Deletes the Order by id.
        /// </summary>
        /// <param name="id">Order id (guid).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// DELETE /Order/A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568
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
