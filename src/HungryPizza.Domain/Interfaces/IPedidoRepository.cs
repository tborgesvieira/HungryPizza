namespace HungryPizza.Domain.Interfaces
{
    public interface IPedidoRepository : IDisposable
    {
        Pedido Adicionar(Pedido pedido);
        Task<IEnumerable<Pedido>> ObterPedidosUsuarioPaginado(Guid usuarioId, int offset, int limit);
    }
}
