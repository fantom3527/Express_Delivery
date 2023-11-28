using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.WebApi.Controllers
{
    public class UserController : BaseController<IUserService>
    {
        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /User
        /// </remarks>
        /// <returns>Returns Users.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        /// <summary>
        /// Gets User by id.
        /// </summary>
        /// /// <param name="id">User id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /User/7D35C407-7930-4BC8-A1DD-D8610155472A
        /// </remarks>
        /// <returns>Returns User.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> Get([Required] Guid id)
        {
            return Ok(await Service.Get(id));
        }
    }
}
