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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }

        [HttpGet("{query-text/queryText}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetQuery(string queryText)
        {
            return Ok(await Service.GetQuery(queryText));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<Order>(createOrderDto);
            return Ok(await Service.Create(command));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<Order>(updateOrderDto);
            await Service.Update(command);

            return NoContent();
        }

        [HttpPut("status")]
        public async Task<ActionResult> UpdateStatus(Guid id, int orderStatusId, string descriptionUpdateStatus)
        {
            await Service.UpdateStatus(id, orderStatusId, descriptionUpdateStatus);

            return NoContent();
        }

        [HttpPut("assignment-executor/{orderId}/{executorId}")]
        public async Task<ActionResult> AssignmentExecutor(Guid orderId, Guid executorId)
        {
            await Service.AssignmentExecutor(orderId, executorId);

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
