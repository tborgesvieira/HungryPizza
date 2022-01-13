using HungryPizza.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Api.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HungryPizzaConnection");

            services.AddDbContext<HungryPizzaContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
