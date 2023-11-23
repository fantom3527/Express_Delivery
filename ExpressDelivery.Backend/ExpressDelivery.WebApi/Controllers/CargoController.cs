using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CargoController : BaseController<ICargoService>
    {
        /// <summary>
        /// Gets all Cargos.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Cargo
        /// </remarks>
        /// <returns>Returns Cargos.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        //TODO: Добавить актуальный ID тестового.

        /// <summary>
        /// Gets Cargo by id.
        /// </summary>
        /// <param name="id">Cargo id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Cargo/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns Cargo.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Cargo>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }
    }
}
