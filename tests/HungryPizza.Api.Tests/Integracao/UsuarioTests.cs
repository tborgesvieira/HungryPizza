using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Api.Tests.Integracao
{
    public class UsuarioTests : IClassFixture<IntegracaoFixture>
    {
        private readonly IntegracaoFixture _integracaoFixture;

        public UsuarioTests(IntegracaoFixture integracaoFixture)
        {
            _integracaoFixture = integracaoFixture;
        }

        [Fact]
        public async void Usuario_CadastrarUsuario_Invalido()
        {
            //Arrange
            var faker = new Faker();

            var usuarioView = _integracaoFixture.ObterUsuarioModelFake();

            var str = faker.Random.String(300);

            usuarioView.Nome += str;

            usuarioView.Logradouro += str;

            usuarioView.Cidade += str;

            usuarioView.Bairro += str;

            usuarioView.UF += str;

            usuarioView.Cpf += str;

            var jsonData = JsonConvert.SerializeObject(usuarioView);

            var httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            
            //Act
            var req = await _integracaoFixture.ObterClient().PutAsync("/api/criar-usuario", httpContent);

            var retorno = await req.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, req.StatusCode);
            Assert.Contains("\"errors\":{\"UF\":[\"UF deve ter no máximo 2 caracteres\"],\"Cpf\":[\"Verifique o CPF\"],\"Nome\":[\"Nome deve ter no máximo 100 caracteres\"],\"Bairro\":[\"Bairro deve ter no máximo 100 caracteres\"],\"Cidade\":[\"Cidade deve ter no máximo 100 caracteres\"],\"Logradouro\":[\"Logradouro deve ter no máximo 200 caracteres\"]}}",
                        retorno);
        }

        [Fact]
        public async void Usuario_CadastrarUsuario_Valido()
        {
            //Arrange
            var usuarioView = _integracaoFixture.ObterUsuarioModelFake();

            var jsonData = JsonConvert.SerializeObject(usuarioView);

            var httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Act
            var req = await _integracaoFixture.ObterClient().PutAsync("/api/criar-usuario", httpContent);

            var retorno = JsonConvert.DeserializeObject<Api.Model.UsuarioModel>(await req.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, req.StatusCode);
            Assert.NotNull(retorno);
            Assert.Equal(usuarioView.Nome, retorno.Nome);
        }

        [Fact]
        public async void Usuario_CadastrarUsuario_InvalidoDuplicidade()
        {
            //Arrange
            var usuarioView = _integracaoFixture.ObterUsuarioModelFake();

            var jsonData = JsonConvert.SerializeObject(usuarioView);

            var httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Act
            var req = await _integracaoFixture.ObterClient().PutAsync("/api/criar-usuario", httpContent);

            var retorno1 = JsonConvert.DeserializeObject<Api.Model.UsuarioModel>(await req.Content.ReadAsStringAsync());

            req = await _integracaoFixture.ObterClient().PutAsync("/api/criar-usuario", httpContent);

            var retorno2 = await req.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, req.StatusCode);
            Assert.Equal($"Usuário já cadastrado, id {retorno1.Id}", retorno2);
        }
    }
}
