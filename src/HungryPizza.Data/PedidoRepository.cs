using HungryPizza.Data.Context;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;

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
    }
}
