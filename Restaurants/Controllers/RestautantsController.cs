using Application.Features.RestaurantFeatures.Commands;
using DomainServices.Features.RestaurantsFeatures.Commands;
using DomainServices.Features.RestaurantsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestautantsController : ControllerBase
    {
        //private readonly AppDbContext restaurants;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRestaurantsQuery()));
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurant command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateRestaurant command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRestaurantByIdCommand { Id = id }));
        }
    }
}
