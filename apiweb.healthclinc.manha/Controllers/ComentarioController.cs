using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastrar de um novo comentário no repositório
        /// </summary>
        /// <param name="comentario">ccomentário a ser cadastrado</param>
        /// <returns>StatusCode(201)</returns>
        [HttpPost]
        public IActionResult Comentar(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método deletar no repositório
        /// </summary>
        /// <param name="id">Id do comentário a ser deletado</param>
        /// <returns>StatusCode(201) sucess</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método listar comentários no repositório
        /// </summary>
        /// <returns>Retorna uma lista contendo todos os comentários</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Comentario> lista = _comentarioRepository.Listar();

                return Ok(lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método Buscar Por Id de um comentário atráves de seu id
        /// </summary>
        /// <param name="id">Id do coomentário a ser buscado</param>
        /// <returns>Retorna o comentário encontrado</returns>
        [HttpGet]
        public IActionResult BuscarId(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
