using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Data.Tests.Context;
using HungryPizza.Data.UoW;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Data.Tests
{
    public class UsuarioRepositoryTests : IClassFixture<HungryPizzaContextTest>
    {
        private readonly HungryPizzaContextTest _hungryPizzaContextTest;

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioRepositoryTests(HungryPizzaContextTest hungryPizzaContextTest)
        {
            _hungryPizzaContextTest = hungryPizzaContextTest;

            _usuarioRepository = new UsuarioRepository(_hungryPizzaContextTest.ObterContext());

            _unitOfWork = new UnitOfWork(_hungryPizzaContextTest.ObterContext());
        }

        [Fact]
        public async void UsuarioRepository_AdicionarEBuscar_Valido()
        {
            //Arrange            
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                                .CustomInstantiator(f => new Usuario(f.Person.FullName, 
                                                                     f.Person.Cpf(), 
                                                                     "logradorou do usuario", 
                                                                     10, 
                                                                     "bairro usuario", 
                                                                     "Brasília", 
                                                                     "DF"))
                                .Generate();
            //Act
            var usuario = _usuarioRepository.Adicionar(usuarioFaker);

            _unitOfWork.Commit();

            usuario = await _usuarioRepository.ObterPorId(usuario.Id);

            //Assert
            Assert.NotNull(usuario);
            Assert.Equal(usuarioFaker.Id, usuario.Id);
            Assert.Equal(usuarioFaker.Nome, usuario.Nome);
            Assert.Equal(usuarioFaker.Cpf, usuario.Cpf);
            Assert.Equal(usuarioFaker.Endereco.Logradouro, usuario.Endereco.Logradouro);
            Assert.Equal(usuarioFaker.Endereco.Bairro, usuario.Endereco.Bairro);
            Assert.Equal(usuarioFaker.Endereco.Cidade, usuario.Endereco.Cidade);
            Assert.Equal(usuarioFaker.Endereco.UF, usuario.Endereco.UF);
        }

        [Fact]
        public async void UsuarioRepository_Buscar_Nulo()
        {
            //Arrange
            var guid = Guid.NewGuid();

            //Act
            var usuario = await _usuarioRepository.ObterPorId(guid);

            //Assert
            Assert.Null(usuario);
        }
    }
}
