using DomainServices.Features.RestaurantsFeatures.Commands;
using DomainServices.Features.RestaurantsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientsPyPlatId(int id)
        {
            return Ok(await Mediator.Send(new GetIngredientsPlatQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> Create(CreatePlat command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}


    }
}
