using Slots.DAL.Interfaces;
using Slots.DAL.Repositories;
using Slots.Domain.Entity;
using Slots.Service.Implementations;
using Slots.Service.Interfaces;

namespace Slots
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Drink>, DrinkRepository>();
            
            
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IDrinkService, DrinkService>();
            
            
        }
    }
}