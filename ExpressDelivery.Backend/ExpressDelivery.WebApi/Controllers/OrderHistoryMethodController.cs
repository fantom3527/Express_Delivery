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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHistoryMethod>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }
    }
}
