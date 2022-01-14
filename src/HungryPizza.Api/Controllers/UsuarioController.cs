using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Data.UoW;
using HungryPizza.Domain;
using HungryPizza.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _usuarioService = usuarioService;

            _mapper = mapper;

            _unitOfWork = unitOfWork;
        }

        [HttpPut("criar-usuario")]
        public async Task<IActionResult> CriarUsuario(UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.AdicionarUsuario(_mapper.Map<Usuario>(usuarioModel));

                if (!_unitOfWork.Commit())
                {
                    BadRequest("Falha ao gravar no banco de dados");
                }

                return Ok(_mapper.Map<UsuarioModel>(usuario));

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
