﻿using Microsoft.AspNetCore.Authorization;
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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
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

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
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
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
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
                _tiposUsuarioRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
