using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RestaurantFeatures.Commands
{
    public class DeleteRestaurantByIdCommand : IRequest<long?>
    {
        public int Id { get; set; }
        public class DeleteRestaurantByIdCommandHandler : IRequestHandler<DeleteRestaurantByIdCommand, long?>
        {
            private readonly IAppDbContext _context;
            public DeleteRestaurantByIdCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<long?> Handle(DeleteRestaurantByIdCommand command, CancellationToken cancellationToken)
            {
                var Restaurant = await _context.Restaurants.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Restaurant == null) return default;
                _context.Restaurants.Remove(Restaurant);
                await _context.SaveChangesAsync();
                return Restaurant.Id;
            }
        }
    }
}
