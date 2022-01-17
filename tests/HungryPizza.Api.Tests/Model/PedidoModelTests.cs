using HungryPizza.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Domain.ValueObjects;
using HungryPizza.Api.Model;

namespace HungryPizza.Api.Tests.Model
{
    public class PedidoModelTests : IClassFixture<ModelFixture>
    {
        private readonly ModelFixture _modelFixture;

        public PedidoModelTests(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }


        [Fact]
        public void PedidoModel_DominioParaModel_ValidoUmSabor()
        {
            //Arrange
            var faker = new Faker("pt_BR");

            var cpf = new Cpf(faker.Person.Cpf());

            var pedido = new Pedido(cpf, "teste", null, "teste", "teste", "go");

            var pizzaFaker = new Pizza("Teste", 10);

            pedido.AdicionarItem(pizzaFaker, null);

            //Act
            var pedidoModel = _modelFixture.ObterMapper().Map<PedidoRetornoModel>(pedido);

            //Assert
            Assert.NotNull(pedidoModel);
            Assert.Equal(10, pedidoModel.ValorPedido);
        }

        [Fact]
        public void PedidoModel_DominioParaModel_ValidoDoisSabores()
        {
            //Arrange
            var faker = new Faker("pt_BR");

            var cpf = new Cpf(faker.Person.Cpf());

            var pedido = new Pedido(cpf, "teste", null, "teste", "teste", "go");

            var pizzaFaker1 = new Pizza("Teste", 10);
            
            var pizzaFaker2 = new Pizza("Teste", 20);

            pedido.AdicionarItem(pizzaFaker1, pizzaFaker2);

            //Act
            var pedidoModel = _modelFixture.ObterMapper().Map<PedidoRetornoModel>(pedido);

            //Assert
            Assert.NotNull(pedidoModel);
            Assert.Equal(15, pedidoModel.ValorPedido);
        }
    }
}
