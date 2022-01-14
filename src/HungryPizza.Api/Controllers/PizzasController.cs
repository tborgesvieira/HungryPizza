using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IMapper _mapper;

        public PizzasController(IPizzaRepository pizzaRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
        }

        [HttpGet("obter-pizzas-cardapio")]
        public async Task<IActionResult> ObterPizzasCardapio()
        {
             var pizzas = await _pizzaRepository.ObterTodos();

            return Ok(_mapper.Map<IEnumerable<PizzaModel>>(pizzas));
        }
    }
}
