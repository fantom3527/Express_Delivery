﻿using ExpressDelivery.Application.Services.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressDelivery.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderHistoryController : BaseController<IOrderHistoryService>
    {
        /// <summary>
        /// Gets all OrderHistories.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /OrderHistory
        /// </remarks>
        /// <returns>Returns OrderHistories.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        /// <summary>
        /// Gets OrderHistories by id.
        /// </summary>
        /// <param name="orderId">Order id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /OrderHistory/A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568
        /// </remarks>
        /// <returns>Returns OrderHistories.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllByOrder([Required] Guid orderId)
        {
            return Ok(await Service.GetAllByOrder(orderId));
        }
    }
}
