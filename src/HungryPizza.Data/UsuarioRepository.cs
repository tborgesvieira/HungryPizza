using HungryPizza.Data.Context;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HungryPizzaContext _hungryPizzaContext;

        public UsuarioRepository(HungryPizzaContext hungryPizzaContext)
        {
            _hungryPizzaContext = hungryPizzaContext;
        }

        public void Dispose()
        {
            _hungryPizzaContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            _hungryPizzaContext?.Add(usuario);

            return usuario;
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _hungryPizzaContext.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> ObterPorCpf(Cpf cpf)
        {            
            return await _hungryPizzaContext.Usuarios.Where(c => c.Cpf.CpfLimpo.Equals(cpf.CpfLimpo)).FirstOrDefaultAsync();
        }
    }
}
