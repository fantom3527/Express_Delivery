using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Gets Cargo by id.
        /// </summary>
        /// <param name="id">Cargo id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /Cargo/66945C5A-7506-4D3D-BE01-49867C4E0A04
        /// </remarks>
        /// <returns>Returns Cargo.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Cargo>> Get([Required] Guid id)
        {
            try
            {
                return Ok(await Service.Get(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Add Order to Cargo.
        /// </summary>
        /// Sample request:
        /// <remarks>
        /// PUT /Cargo
        /// {
        ///     id: "07E0E4F3-6DCB-4F50-851C-D24731849451"
        ///     orderId: "A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"
        /// }
        /// </remarks>
        /// <param name="id">Cargo id (Guid).</param>
        /// <param name="orderId">Order id (Guid).</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut("add-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddOrder([FromQuery][Required] Guid id, [FromQuery][Required] Guid orderId)
        {
            await Service.AddOrder(id, orderId);

            return NoContent();
        }
    }
}
