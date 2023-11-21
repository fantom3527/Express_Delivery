using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderController
    {
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper) => _mapper = mapper;
    }
}
