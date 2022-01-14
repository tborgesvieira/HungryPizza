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
