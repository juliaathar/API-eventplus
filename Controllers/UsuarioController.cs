using apiweb.eventplus.Domains;
using apiweb.eventplus.Interfaces;
using apiweb.eventplus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.eventplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult Get (Guid id)
        {
            try
            {
               Usuario usuario = _usuarioRepository.BuscarPorId(id);

                return Ok(usuario);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult GetByEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                return Ok(usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
