using DomainModel.Models;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Features.RestaurantsFeatures.Queries
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<Restaurant>>
    {
        public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<Restaurant>>
        {
            private readonly IAppDbContext _context;
            public GetAllRestaurantsQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Restaurant>> Handle(GetAllRestaurantsQuery query, CancellationToken cancellationToken)
            {
                var RestaurantList = await _context.Restaurants.ToListAsync();
                if (RestaurantList == null)
                {
                    return null;
                }
                return RestaurantList.AsReadOnly();
            }
        }
    }
}
