namespace HungryPizza.Domain.Interfaces
{
    public interface IPedidoRepository : IDisposable
    {
        Pedido Adicionar(Pedido pedido);
    }
}
