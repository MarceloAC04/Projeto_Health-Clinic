using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="tiposUsuario">Novo tipo usuário a ser cadastrado</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona  o método de listar todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de todos os tipos usuários cadastardos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuario> lista = _tiposUsuarioRepository.Listar();

                return Ok(lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint que aciona o método deletar de um tipo usuário
        /// </summary>
        /// <param name="id">Id do tipo usuário a ser deletado</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método atualizar de um tipo usuário
        /// </summary>
        /// <param name="id">Id do tipo usuário a ser atualizado</param>
        /// <param name="tiposUsuario">Corpo do tipo usuário a ser cadastrado</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPut]
        public IActionResult Put(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
