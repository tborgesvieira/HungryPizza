namespace HungryPizza.Domain.Interfaces
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Task<Usuario> ObterPorId(Guid id);
    }
}
