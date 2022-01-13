using HungryPizza.Domain;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Data.Context
{
    public class HungryPizzaContext : DbContext
    {
        public HungryPizzaContext(DbContextOptions<HungryPizzaContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HungryPizzaContext).Assembly);
        }
    }
}
