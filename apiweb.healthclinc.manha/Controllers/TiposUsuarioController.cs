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
        /// Endpoint que aciona o metodo de cadastrado de um novo tipo de usuario
        /// </summary>
        /// <param name="tiposUsuario">Novo tipo usuario a ser cadastrado</param>
        /// <returns>StatusCode(201)</returns>
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
        /// Endpoint que aciona  o metodo de listar todos os tipos de usuario
        /// </summary>
        /// <returns>Retorna uma lista de todos os tipos usuarios cadastardos</returns>
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
        /// Endpoint que aciona o metodo deletar de um tipo usuario
        /// </summary>
        /// <param name="id">Id do tipo usuario a ser deletado</param>
        /// <returns>StatusCode(201)</returns>
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
        /// Endpoint que aciona o metodo atualizar de um tipo usuario
        /// </summary>
        /// <param name="id">Id do tipo usuario a ser atualizado</param>
        /// <param name="tiposUsuario">Corpo do tipo usuario a ser cadastrado</param>
        /// <returns></returns>
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
