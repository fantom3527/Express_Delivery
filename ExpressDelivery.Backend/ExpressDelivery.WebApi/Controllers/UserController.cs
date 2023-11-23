using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;

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

        //TODO: добавить актуальный id

        /// <summary>
        /// Gets User by id.
        /// </summary>
        /// /// <param name="id">User id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /User/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns User.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            return Ok(await Service.Get(id));
        }
    }
}
