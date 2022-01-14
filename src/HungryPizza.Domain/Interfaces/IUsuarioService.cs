namespace HungryPizza.Domain.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
    }
}
