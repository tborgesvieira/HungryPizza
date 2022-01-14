using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Api.Model;
using HungryPizza.Domain;
using Xunit;

namespace HungryPizza.Api.Tests.Model
{
    public class UsuarioModelTests : IClassFixture<ModelFixture>
    {
        private readonly ModelFixture _fixture;

        public UsuarioModelTests(ModelFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void UsuarioModel_ModelParaDominio_Valido()
        {
            //Arrange
            var usuarioModel = new Faker<UsuarioModel>("pt_BR")
                                .RuleFor(c => c.Nome, f => f.Person.FullName)
                                .RuleFor(c => c.Cpf, f => f.Person.Cpf())
                                .RuleFor(c => c.Logradouro, "Nome logradouro")
                                .RuleFor(c => c.Bairro, "Nome bairro")
                                .RuleFor(c => c.Cidade, "Nome cidade")
                                .RuleFor(c => c.UF, "UF")
                                .Generate();

            //Act
            var usuario = _fixture.ObterMapper().Map<Usuario>(usuarioModel);

            //Assert
            AssertObject(usuario, usuarioModel);
        }        

        [Fact]
        public void UsuarioModel_DominioParaModelo_Valido()
        {
            //Arrange
            var usuario = new Faker<Usuario>("pt_BR")
                                .CustomInstantiator(f => new Usuario(f.Person.FullName,
                                                                     f.Person.Cpf(),
                                                                     "logradorou do usuario",
                                                                     10,
                                                                     "bairro usuario",
                                                                     "Brasília",
                                                                     "DF"))
                                .Generate();

            //Act
            var usuarioModel = _fixture.ObterMapper().Map<UsuarioModel>(usuario);

            //Assert
            AssertObject(usuario, usuarioModel);
        }

        private void AssertObject(Usuario usuario, UsuarioModel usuarioModel)
        {
            Assert.Equal(usuarioModel.Nome, usuario.Nome);
            Assert.Equal(usuarioModel.Cpf, usuario.Cpf.ObterCpfFormatado());
            Assert.Equal(usuarioModel.Logradouro, usuario.Endereco.Logradouro);
            Assert.Equal(usuarioModel.Cidade, usuario.Endereco.Cidade);
            Assert.Equal(usuarioModel.Bairro, usuario.Endereco.Bairro);
            Assert.Equal(usuarioModel.UF, usuario.Endereco.UF);
        }
    }
}
