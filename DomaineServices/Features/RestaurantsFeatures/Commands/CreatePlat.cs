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
    public class CreatePlat : IRequest<int?>
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Catrtegorie { get; set; }
        public long RestaurantId { get; set; }
        public List<Ingredient> Ingredients { get; set; }


        public class CreatePlatCommandHandler : IRequestHandler<CreatePlat, int?>
        {
            private readonly IAppDbContext _context;
            public CreatePlatCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<int?> Handle(CreatePlat command, CancellationToken cancellationToken)
            {
                var plat = new Plat();
                plat.Id = null;
                plat.Name = command.Name;
                plat.Image = command.Image;
                plat.Catrtegorie = command.Catrtegorie;
                plat.RestaurantId = command.RestaurantId;
                plat.Ingredients = command.Ingredients;
                _context.Plats.Add(plat);
                await _context.SaveChangesAsync();
                return plat.Id;
            }


        }
    }
}
