using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderStatusController : BaseController<IOrderStatusService>
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }
    }
}
