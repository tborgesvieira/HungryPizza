using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Data.Tests.Context;
using HungryPizza.Data.UoW;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Data.Tests
{
    public class PedidoRepositoryTests : IClassFixture<HungryPizzaContextTest>
    {
        private readonly HungryPizzaContextTest _hungryPizzaContextTest;

        private readonly IPedidoRepository _pedidoRepository;

        private readonly IPizzaRepository _pizzaRepository;

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public PedidoRepositoryTests(HungryPizzaContextTest hungryPizzaContextTest)
        {
            _hungryPizzaContextTest = hungryPizzaContextTest;

            _unitOfWork = new UnitOfWork(_hungryPizzaContextTest.ObterContext());

            _pizzaRepository = new PizzaRepository(_hungryPizzaContextTest.ObterContext());

            _pedidoRepository = new PedidoRepository(_hungryPizzaContextTest.ObterContext());

            _usuarioRepository = new UsuarioRepository(_hungryPizzaContextTest.ObterContext());
        }


        [Fact]
        public async void PedidoRepository_AdicionarPedido_Valido()
        {
            //Arrange
            var cpf =new Cpf(new Faker().Person.Cpf());

            var pedidoAdd = new Pedido(cpf, "teste", 1, "teste", "teste", "go");

            var pizzas = await _pizzaRepository.ObterTodos();

            pedidoAdd.AdicionarItem(pizzas.First(), pizzas.Last());

            //Act
            var pedido = _pedidoRepository.Adicionar(pedidoAdd);

            var save = _unitOfWork.Commit();

            //Assert
            Assert.NotNull(pedido);

            Assert.True(save);
        }


        [Fact]
        public async void PedidoRepository_BuscarPedidoUsuario_Valido()
        {
            //Arrange
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                                .CustomInstantiator(f => new Usuario(f.Person.FullName,
                                                                     f.Person.Cpf(),
                                                                     "logradorou do usuario",
                                                                     10,
                                                                     "bairro usuario",
                                                                     "Brasília",
                                                                     "DF")).Generate();

            var usuario = _usuarioRepository.Adicionar(usuarioFaker);

            _unitOfWork.Commit();

            usuario = await _usuarioRepository.ObterPorId(usuario.Id);

            var pizzas = await _pizzaRepository.ObterTodos();            

            for (int i = 0; i < 100; i++)
            {
                var pedidoAdd = new Pedido(usuarioFaker);                

                pedidoAdd.AdicionarItem(pizzas.First(), pizzas.Last());

                _pedidoRepository.Adicionar(pedidoAdd);                
            }

            _unitOfWork.Commit();

            //Act
            var pedidos = await _pedidoRepository.ObterPedidosUsuarioPaginado(usuarioFaker.Id, 1, 10);

            //Assert
            Assert.Equal(10, pedidos.Count());
        }
    }
}
