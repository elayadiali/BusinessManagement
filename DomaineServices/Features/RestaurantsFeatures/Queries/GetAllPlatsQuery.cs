using DomainModel.Models;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Features.RestaurantsFeatures.Queries
{
    public class GetAllPlatsQuery : IRequest<IEnumerable<Plat>>
    {
        public class GetAllPlatsQueryHandler : IRequestHandler<GetAllPlatsQuery, IEnumerable<Plat>>
        {
            private readonly IAppDbContext _context;
            public GetAllPlatsQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Plat>> Handle(GetAllPlatsQuery query, CancellationToken cancellationToken)
            {
                var PlatList = await _context.Plats.ToListAsync();
                if (PlatList == null)
                {
                    return null;
                }
                return PlatList.AsReadOnly();
            }
        }
    }
}
