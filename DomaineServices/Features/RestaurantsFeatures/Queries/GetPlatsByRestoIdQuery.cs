using DomainModel.Models;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Features.RestaurantsFeatures.Queries
{
    public class GetPlatsByRestoIdQuery : IRequest<IEnumerable<Plat>>
    {
        public long Id { get; set; }
        public class GetAllPlatsByRestoIdQueryHandler : IRequestHandler<GetPlatsByRestoIdQuery, IEnumerable<Plat>>
        {
            private readonly IAppDbContext _context;
            public GetAllPlatsByRestoIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Plat>> Handle(GetPlatsByRestoIdQuery query, CancellationToken cancellationToken)
            {
                var PlatList = _context.Plats.Where(c=>c.RestaurantId == query.Id);
                if (PlatList == null)
                {
                    return null;
                }
                return PlatList;
            }
        }
    }
}
