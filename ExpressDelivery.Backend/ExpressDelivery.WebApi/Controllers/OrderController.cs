using AutoMapper;
using ExpressDelivery.Application.Dto.OrderDto;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderController : BaseController<IOrderService>
    {
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Order
        /// </remarks>
        /// <returns>Returns Orders.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        /// <summary>
        /// Gets Order by id.
        /// </summary>
        /// <param name="id">Order id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Order/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns Order.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }

        /// <summary>
        /// Gets Order by query.
        /// </summary>
        /// <param name="queryText">query Text (string).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Order/query-text/new
        /// </remarks>
        /// <returns>Returns Order.</returns>
        /// <response code="200">Success</response>
        [HttpGet("query-text/{queryText}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Order>>> GetQuery(string queryText)
        {
            return Ok(await Service.GetQuery(queryText));
        }

        /// <summary>
        /// Creates the Order.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /Order
        /// {
        ///     name: "Order name"
        ///     executorId: "13360799-8908-4449-9CA9-64A3AA5AEA8C"
        ///     userId: "13360799-8908-4449-9CA9-64A3AA5AEA8C"
        ///     receiptAddress: "Komarovo"
        ///     deliveryAddress: "Moscow"
        ///     receiptTime: "10.10.2023" 
        ///     deliveryTime: "20.10.2023"
        ///     description: "Order description"
        ///     orderStatusId: "1"
        /// }
        /// </remarks>
        /// <param name="createOrderDto">CreateOrderDto object.</param>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create(CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<Order>(createOrderDto);
            return Ok(await Service.Create(command));
        }

        /// <summary>
        /// Updates the Order.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Order
        /// {
        ///     name: "Order name"
        ///     receiptAddress: "Novosibirsk"
        ///     deliveryAddress: "Moscow"
        ///     receiptTime: "12.10.2023" 
        ///     deliveryTime: "23.10.2023"
        ///     description: "Order description"
        /// }
        /// </remarks>
        /// <param name="updateOrderDto">UpdateOrderDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<Order>(updateOrderDto);
            await Service.Update(command);

            return NoContent();
        }

        /// <summary>
        /// Changes status the Order.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Order/status
        /// {
        ///     id: "Order id"
        ///     orderStatusId: "Order status id"
        ///     descriptionUpdateStatus: "Description Update Status"
        /// }
        /// </remarks>
        /// <param name="id">Order id.</param>
        /// <param name="orderStatusId">Order status id.</param>
        /// <param name="descriptionUpdateStatus">Description update Status for order history.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatus([FromQuery] Guid id, [FromQuery] int orderStatusId, [FromQuery] string descriptionUpdateStatus)
        {
            await Service.UpdateStatus(id, orderStatusId, descriptionUpdateStatus);

            return NoContent();
        }

        /// <summary>
        /// Assignments Executor To Order.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Order/assignment-executor
        /// {
        ///     orderId: "Order id"
        ///     executorId: "Executor id"
        /// }
        /// </remarks>
        /// <param name="orderId">Order id.</param>
        /// <param name="executorId">Order status id.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("assignment-executor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AssignmentExecutor([FromQuery] Guid orderId, [FromQuery] Guid executorId)
        {
            await Service.AssignmentExecutor(orderId, executorId);

            return NoContent();
        }

        /// <summary>
        /// Deletes the Order by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Order/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Order id (guid).</param>
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
