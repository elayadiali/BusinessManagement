using DomainModel.Models;
using DomainServices.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Features.RestaurantsFeatures.Commands
{
    public class CreateRestaurant : IRequest<long?>
    {
        public string Name { get; set; }
 
        
        public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurant, long?>
        {
            private readonly IAppDbContext _context;
            public CreateRestaurantCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<long?> Handle(CreateRestaurant command, CancellationToken cancellationToken)
            {
                var restaurant = new Restaurant();
                restaurant.Name = command.Name;
                
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return restaurant.Id;
            }
        }
    }
}
