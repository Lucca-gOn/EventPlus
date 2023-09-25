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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(novaInstituicao);

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
                return Ok(_instituicaoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
          
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
