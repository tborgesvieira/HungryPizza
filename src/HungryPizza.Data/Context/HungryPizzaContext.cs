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

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HungryPizzaContext).Assembly);
        }
    }
}
