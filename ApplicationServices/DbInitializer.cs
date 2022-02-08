using ApplicationServices.Context;
using DomainModel.Models;

namespace DomainServices.Interfaces
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Restaurants.Any())
            {
                return;
            }



            var plats = new Plat[]
            {
                new Plat {Id=null,Name="Spaghetti",Image="",Catrtegorie="Les pates"},

                new Plat {Id=null,Name="Pizza",Image="",Catrtegorie="Les pates"}
            };
            context.Plats.AddRange(plats);
            var restaurants = new Restaurant[]
            {
                new Restaurant{Id=null,Name="Luigi",Plats = new  List<Plat>(plats)},
                new Restaurant{Id=null,Name="Venisia"}
            };

            context.Restaurants.AddRange(restaurants);

            

            context.SaveChanges();

        }

    }
}
