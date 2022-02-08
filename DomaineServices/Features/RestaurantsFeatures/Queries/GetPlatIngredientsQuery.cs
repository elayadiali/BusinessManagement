using DomainModel.Models;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Features.RestaurantsFeatures.Queries
{
    public class GetIngredientsPlatQuery : IRequest<IEnumerable<Ingredient>>
    {
        public int Id { get; set; }
        public class GetIngredientsPlatQueryHandler : IRequestHandler<GetIngredientsPlatQuery, IEnumerable<Ingredient>>
        {
            private readonly IAppDbContext _context;
            public GetIngredientsPlatQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Ingredient>> Handle(GetIngredientsPlatQuery query, CancellationToken cancellationToken)
            {
                var IngredientList = await _context.Ingredients.Where(c=>c.PlatId == query.Id).ToListAsync();
                if (IngredientList == null)
                {
                    return null;
                }
                return IngredientList.AsReadOnly();
            }
        }
    }
}
