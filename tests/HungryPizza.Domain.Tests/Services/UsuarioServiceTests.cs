using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Domain.Tests.Services
{
    public class UsuarioServiceTests : IClassFixture<ServiceFixture>
    {
        private readonly ServiceFixture _serviceFixture;
        private readonly IUsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;

        public UsuarioServiceTests(ServiceFixture serviceFixture)
        {
            _serviceFixture = serviceFixture;

            _usuarioRepository = new Mock<IUsuarioRepository>();

            _usuarioService = new UsuarioService(_usuarioRepository.Object);            
        }

        [Fact]
        public async void UsuarioService_AdicionarUsuario_JaCadastrado()
        {
            //Arrange
            var usuarioFaker = _serviceFixture.ObterUsuarioFaker();

            _usuarioRepository.Setup(m=>m.ObterPorCpf(usuarioFaker.Cpf)).ReturnsAsync(usuarioFaker);

            //Act            
            var excepton = await Assert.ThrowsAsync<Exception>(async () => await _usuarioService.AdicionarUsuario(usuarioFaker));

            //Assert
            Assert.Equal($"Usuário já cadastrado, id {usuarioFaker.Id}", excepton.Message);
            _usuarioRepository.Verify(m => m.ObterPorCpf(usuarioFaker.Cpf), Times.Once);
            _usuarioRepository.Verify(m => m.Adicionar(usuarioFaker), Times.Never);
        }

        [Fact]
        public async void UsuarioService_AdicionarUsuario_Adiciionar()
        {
            //Arrange
            var usuarioFaker = _serviceFixture.ObterUsuarioFaker();

            _usuarioRepository.Setup(m => m.Adicionar(usuarioFaker)).Returns(usuarioFaker);

            //Act            
            var usuario = await _usuarioService.AdicionarUsuario(usuarioFaker);

            //Assert
            Assert.NotNull(usuario);
            _usuarioRepository.Verify(m => m.ObterPorCpf(usuarioFaker.Cpf), Times.Once);
            _usuarioRepository.Verify(m => m.Adicionar(usuarioFaker), Times.Once);
        }
    }
}
