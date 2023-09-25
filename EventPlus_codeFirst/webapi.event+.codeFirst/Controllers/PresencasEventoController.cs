using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;
using webapi.event_.codeFirst.Repositories;

namespace webapi.event_.codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Aluno")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Aluno")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencasEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_presencasEventoRepository.BuscarPorId(id)!);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Aluno")]
        public IActionResult Put(Guid id, PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Atualizar(id, presencasEvento);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarMeus")]
        [Authorize(Roles = "Aluno")]
        public IActionResult GetMyEvents(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMeusEventos(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
