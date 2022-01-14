using HungryPizza.Data;
using HungryPizza.Domain.Interfaces;

namespace HungryPizza.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServicesApi(this IServiceCollection services)
        {
            //Mapper
            services.AddAutoMapper(typeof(Program));

            //Repository
            services.AddScoped<IPizzaRepository, PizzaRepository>();
        }
    }
}
