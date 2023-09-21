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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post (TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
               TiposUsuario tiposUsuario = _tiposUsuarioRepository.BuscarPorId(id);

                return Ok(tiposUsuario);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut ("{id}")]
        public IActionResult Put(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);

                return Ok(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(203);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuario> listaTiposUsuario = _tiposUsuarioRepository.Listar();

                return Ok(listaTiposUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
