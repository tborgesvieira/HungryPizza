using HungryPizza.Api.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Api.Tests.Integracao
{
    public class PedidoTests : IClassFixture<IntegracaoFixture>
    {
        private readonly IntegracaoFixture _integracaoFixture;

        public PedidoTests(IntegracaoFixture integracaoFixture)
        {
            _integracaoFixture = integracaoFixture;
        }


        [Fact]
        public async void FazerPedido()
        {
            //Arrange
            var pedidoModel = await ObterPedidoModel();

            var jsonData = JsonConvert.SerializeObject(pedidoModel);

            var httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var httpClient = _integracaoFixture.ObterClient();

            //Act
            var req = await httpClient.PutAsync("/api/cadastrar-pedido", httpContent);

            var retorno = await req.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, req.StatusCode);
            Assert.Equal("Pedido realizado", retorno);
        }

        private async Task<PedidoModel> ObterPedidoModel()
        {            
            var pizzas = await ObterCardapio();

            var pedidoModel = new PedidoModel()
            {
                CPF = "736.772.490-82",
                Logradouro = "Teste",
                Bairro = "teste",
                Cidade = "teste",
                UF = "GO",
                Itens = new List<PedidoItemModel>()
                {
                    new PedidoItemModel() { Sabor1 = pizzas.First().Id, Sabor2 = pizzas.Last().Id }
                }
            };

            return pedidoModel;
        }

        private async Task<IEnumerable<Api.Model.PizzaModel>> ObterCardapio()
        {
            
            var httpClient = _integracaoFixture.ObterClient();
            
            var req = await httpClient.GetAsync("/api/obter-pizzas-cardapio");

            var retorno = JsonConvert.DeserializeObject<IEnumerable<Api.Model.PizzaModel>>(await req.Content.ReadAsStringAsync());

            return retorno;
        }
    }
}
