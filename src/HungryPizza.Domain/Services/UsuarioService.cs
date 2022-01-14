using HungryPizza.Domain.Interfaces;

namespace HungryPizza.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            var usuarioConsulta = await _usuarioRepository.ObterPorCpf(usuario.Cpf);

            if(usuarioConsulta != null)
            {
                //Está com exception mas o correto é uma notificação de domínio
                throw new Exception($"Usuário já cadastrado, id {usuario.Id}");                
            }

            return _usuarioRepository.Adicionar(usuario);
        }        
    }
}
