using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Domain.Tests.Domain
{
    public class PedidoTests
    {

        [Fact]
        public void Pedido_CriarComUmaPizzaSemUsuario_ValidoDuasPizzas()
        {
            //Arrange
            var pizza = new Pizza("Sabor de Teste", 50);

            //Act
            var pedido = new Pedido("teste", null, "teste", "teste", "go");

            pedido.AdicionarItem(pizza, null);

            pedido.IsValid();

            //Assert
            Assert.Equal(50, pedido.ValorPedido);
            Assert.Equal(1, pedido.Itens.Count);
        }

        [Fact]
        public void Pedido_CriarComUmaPizzaSemUsuario_Valido()
        {
            //Arrange
            var pizza = new Pizza("Sabor de Teste", 50);

            //Act
            var pedido = new Pedido("teste", null, "teste", "teste", "go");

            pedido.AdicionarItem(pizza, null);

            pedido.IsValid();

            //Assert
            Assert.Equal(50, pedido.ValorPedido);
            Assert.Equal(1, pedido.Itens.Count);
        }

        [Fact]
        public void Pedido_CriarComUmaPizzaSemUsuario_InvalidoPedidoSemItem()
        {
            //Arrange
            //Act
            var pedido = new Pedido("teste", null, "teste", "teste", "go");            

            var exception = Assert.Throws<Exception>(() => pedido.IsValid());

            //Assert
            Assert.Equal("Pedido deve ter ao menos 1 item", exception.Message);
        }

        [Fact]
        public void Pedido_CriarComUmaPizzaSemUsuario_InvalidoPedidoComItemExcedente()
        {
            //Arrange
            var pizzas = new Faker<Pizza>()
                            .CustomInstantiator(f => new Pizza(f.Random.String(10), f.Random.Double(40, 60)))
                            .Generate(11);
            //Act
            var pedido = new Pedido("teste", null, "teste", "teste", "go");

            pizzas.ForEach(pi => pedido.AdicionarItem(pi, null));

            var exception = Assert.Throws<Exception>(() => pedido.IsValid());

            //Assert
            Assert.Equal($"Quantidade máxima de itens deve ser {Pedido.Quantidade_Maxima_Itens}", exception.Message);
        }

        [Fact]
        public void Pedido_CriarComUmaPizzaComUsuario_Valido()
        {
            //Arrange
            var pizza = new Pizza("Sabor de Teste", 50);

            var usuario = new Faker<Usuario>()
                            .CustomInstantiator(f => new Usuario(f.Person.FullName,
                                                                f.Person.Cpf(),
                                                                "Teste logradouro",
                                                                11,
                                                                "tete bairro",
                                                                "teste cidade",
                                                                "go")).Generate();

            //Act
            var pedido = new Pedido(usuario);

            pedido.AdicionarItem(pizza, null);

            pedido.IsValid();

            //Assert
            Assert.Equal(50, pedido.ValorPedido);
            Assert.Equal(1, pedido.Itens.Count);
            Assert.NotNull(pedido.EnderecoEntrega);
        }
    }
}
