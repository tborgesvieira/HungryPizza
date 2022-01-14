using HungryPizza.Data.Tests.Context;
using HungryPizza.Domain.Interfaces;
using System.Linq;
using Xunit;

namespace HungryPizza.Data.Tests
{
    public class PizzaRepositoryTests : IClassFixture<HungryPizzaContextTest>
    {
        private readonly HungryPizzaContextTest _hungryPizzaContextTest;
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaRepositoryTests(HungryPizzaContextTest hungryPizzaContextTest)
        {
            _hungryPizzaContextTest = hungryPizzaContextTest;

            _pizzaRepository = new PizzaRepository(_hungryPizzaContextTest.ObterContext());
        }

        [Fact]
        public async void PizzaRepository_ObterTodos_PossuiDadosIniciais()
        {
            //Arrange
            //Act
            var pizzas = await _pizzaRepository.ObterTodos();

            //Assert
            Assert.NotNull(pizzas);
            Assert.Equal(6, pizzas.Count());            
        }
    }
}
