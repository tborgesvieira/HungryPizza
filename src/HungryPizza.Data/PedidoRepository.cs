using HungryPizza.Data.Context;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private HungryPizzaContext _hungryPizzaContext;

        public PedidoRepository(HungryPizzaContext hungryPizzaContext)
        {
            _hungryPizzaContext = hungryPizzaContext;
        }

        public void Dispose()
        {
            _hungryPizzaContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public Pedido Adicionar(Pedido pedido)
        {
            _hungryPizzaContext.Pedidos.Add(pedido);

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> ObterPedidosUsuarioPaginado(Guid usuarioId, int offset, int limit)
        {
            var list = await _hungryPizzaContext.Pedidos
                                .Where(c => c.Usuario.Id.Equals(usuarioId))
                                .AsNoTracking()
                                .OrderByDescending(c => c.DataHora)
                                .Skip(offset)
                                .Take(limit)
                                .ToListAsync();

            return list;
        }
    }
}
