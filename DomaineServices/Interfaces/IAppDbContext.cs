using DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Plat> Plats { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        Task<int> SaveChangesAsync();
    }
}
