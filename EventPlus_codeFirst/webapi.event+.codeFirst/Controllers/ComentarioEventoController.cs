using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.codeFirst.Domains;
using webapi.event_.codeFirst.Interfaces;
using webapi.event_.codeFirst.Repositories;

namespace webapi.event_.codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public IActionResult Post(ComentariosEvento novoComentario)
        {


            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentario);

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
                return Ok(_comentarioEventoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);

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
               return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
