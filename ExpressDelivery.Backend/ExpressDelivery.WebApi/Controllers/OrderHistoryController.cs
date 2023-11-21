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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllByOrder(Guid orderId)
        {
            //
            return Ok(await Service.GetAllByOrder(orderId));
        }
    }
}
