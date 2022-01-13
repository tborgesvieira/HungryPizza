using HungryPizza.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Data.Tests.Context
{
    public class HungryPizzaContextTest : IDisposable
    {
        private readonly HungryPizzaContext _hungryPizzaContext;

        public void Dispose()
        {
            _hungryPizzaContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public HungryPizzaContext ObterContext()
        {
            return _hungryPizzaContext;
        }

        public HungryPizzaContextTest()
        {
            var builder = new DbContextOptionsBuilder<HungryPizzaContext>();

            builder.UseInMemoryDatabase(databaseName: "HungryPizzaDbInMemory");

            var dbContextOptions = builder.Options;

            _hungryPizzaContext = new HungryPizzaContext(dbContextOptions);

            _hungryPizzaContext.Database.EnsureDeleted();

            _hungryPizzaContext.Database.EnsureCreated();
        }
    }
}
