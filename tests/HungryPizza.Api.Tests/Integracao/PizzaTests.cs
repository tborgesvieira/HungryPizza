using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HungryPizza.Api.Tests.Integracao
{
    public class PizzaTests : IClassFixture<IntegracaoFixture>
    {
        private readonly IntegracaoFixture _integracaoFixture;

        public PizzaTests(IntegracaoFixture integracaoFixture)
        {
            _integracaoFixture = integracaoFixture;
        }

        [Fact]
        public async void ObterCardapio()
        {
            //Arrange
            var httpClient = _integracaoFixture.ObterClient();
            //Act
            var req = await httpClient.GetAsync("/api/obter-pizzas-cardapio");

            var retorno = JsonConvert.DeserializeObject<IEnumerable<Api.Model.PizzaModel>>(await req.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(req.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(retorno);
            Assert.Equal(6, retorno.Count());
        }
    }
}
