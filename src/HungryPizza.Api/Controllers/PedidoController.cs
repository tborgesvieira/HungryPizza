using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Data.UoW;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoController(
            IUsuarioRepository usuarioRepository,
            IPizzaRepository pizzaRepository,
            IPedidoRepository pedidoRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _pizzaRepository = pizzaRepository;
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPut("cadastrar-pedido")]
        public async Task<IActionResult> CadastrarPedido(PedidoModel pedidoModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Cpf cpf;

            try
            {
                cpf = new Cpf(pedidoModel.CPF);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

            try
            {
                var usuario = await _usuarioRepository.ObterPorCpf(cpf);

                Pedido pedido;

                if (usuario == null)
                {
                    pedido = CriarPedidoSemUsuario(pedidoModel, cpf);
                }
                else
                {
                    pedido = CriarPedidoComUsuario(pedidoModel, usuario);
                }

                await AdidicionarItens(pedidoModel, pedido);

                pedido = _pedidoRepository.Adicionar(pedido);

                if (!_unitOfWork.Commit())
                {
                    throw new Exception("Falha ao gravar pedido");
                }

                return Ok(_mapper.Map<PedidoModel>(pedido));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        private async Task AdidicionarItens(PedidoModel pedidoModel, Pedido pedido)
        {
            foreach (var pedidoItem in pedidoModel.Itens)
            {
                var pizza1 = await ObterPizza(pedidoItem.Sabor1, pedidoItem);

                Pizza pizza2 = null;

                if (pedidoItem.Sabor2 != null)
                {
                    pizza2 = await ObterPizza(pedidoItem.Sabor2.Value, pedidoItem);
                }

                pedido.AdicionarItem(pizza1, pizza2);
            }
        }

        private async Task<Pizza> ObterPizza(Guid sabor1, PedidoItemModel pedidoItem)
        {
            var pizza = await _pizzaRepository.ObterPorId(pedidoItem.Sabor1);

            if (pizza == null)
            {
                throw new Exception("Sabor não localizado");
            }

            return pizza;
        }

        private Pedido CriarPedidoComUsuario(PedidoModel pedidoModel, Usuario usuario)
        {
            var pedido = new Pedido(usuario);

            return pedido;
        }

        private Pedido CriarPedidoSemUsuario(PedidoModel pedidoModel, Cpf cpf)
        {
            var pedido = new Pedido(cpf, pedidoModel.Logradouro, pedidoModel.Numero, pedidoModel.Bairro, pedidoModel.Cidade, pedidoModel.UF);

            return pedido;
        }
    }
}
