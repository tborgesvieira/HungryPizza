using HungryPizza.Domain.ValueObjects;

namespace HungryPizza.Domain.Interfaces
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Task<Usuario> ObterPorId(Guid id);
        Task<Usuario> ObterPorCpf(Cpf cpf);
    }
}
