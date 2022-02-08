using DomainModel.Models;
using DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Context
{
    public class AppDbContext :DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Plat> Plats { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
