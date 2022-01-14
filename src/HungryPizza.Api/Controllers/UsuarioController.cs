using HungryPizza.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut("criar-usuario")]
        public async Task<IActionResult>CriarUsuario(UsuarioModel usuario)
        {

        }
    }
}
