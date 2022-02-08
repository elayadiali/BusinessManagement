using DomainServices.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Features.RestaurantsFeatures.Commands
{
    public class UpdateRestaurant : IRequest<long?>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurant, long?>
        {
            private readonly IAppDbContext _context;
            public UpdateRestaurantCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<long?> Handle(UpdateRestaurant command, CancellationToken cancellationToken)
            {
                var Restaurant = _context.Restaurants.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Restaurant == null)
                {
                    return default;
                }
                else
                {
                    Restaurant.Name = command.Name;
                    await _context.SaveChangesAsync();
                    return Restaurant.Id;
                }
            }
        }
    }
}
