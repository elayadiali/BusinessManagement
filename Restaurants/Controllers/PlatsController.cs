using DomainServices.Features.RestaurantsFeatures.Commands;
using DomainServices.Features.RestaurantsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatsController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPlatsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatsByRestaurant(long id)
        {
            return Ok(await Mediator.Send(new GetPlatsByRestoIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlat command)
        {
            return Ok(await Mediator.Send(command));
        }


    }
}
