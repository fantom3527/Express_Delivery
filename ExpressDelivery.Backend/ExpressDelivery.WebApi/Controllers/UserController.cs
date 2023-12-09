using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Dto.UserDto;
using ExpressDelivery.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UserController : BaseController<IUserService>
    {
        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /User
        /// </remarks>
        /// <returns>Returns Users.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Service.GetAll(cancellationToken));
        }

        /// <summary>
        /// Gets User by id.
        /// </summary>
        /// <param name="id">User id (guid).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /User/7D35C407-7930-4BC8-A1DD-D8610155472A
        /// </remarks>
        /// <returns>Returns User.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserDto>> Get([Required] Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await Service.Get(id, cancellationToken));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
