using HungryPizza.Data.Context;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly HungryPizzaContext _hungryPizzaContext;

        public PizzaRepository(HungryPizzaContext hungryPizzaContext)
        {
            _hungryPizzaContext = hungryPizzaContext;
        }

        public void Dispose()
        {
            _hungryPizzaContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<Pizza> ObterPorId(Guid id)
        {
            return await _hungryPizzaContext.Pizzas.FindAsync(id);
        }

        public async Task<IEnumerable<Pizza>> ObterTodos()
        {
            return await _hungryPizzaContext.Pizzas.ToListAsync();
        }
    }
}
