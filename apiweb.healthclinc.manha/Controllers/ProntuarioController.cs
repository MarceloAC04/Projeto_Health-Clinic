using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastrar de um novo prontuário
        /// </summary>
        /// <param name="prontuario">novo prontuário a ser cadastrado</param>
        /// <returns>StatusCode(201) sucess</returns>
        [HttpPost]
        public IActionResult Cadastrar(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de buscar por id de um prontuário
        /// </summary>
        /// <param name="id">Id do prontuário a ser buscado</param>
        /// <returns>Retorna o prontuário encontrado</returns>
        [HttpGet]
        public IActionResult BuscarId(Guid id)
        {
            try
            {
                return Ok(_prontuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de atualizar de um novo prontuário
        /// </summary>
        /// <param name="id">id do prontuário a ser atualizado</param>
        /// <param name="prontuario">corpo do prontuário a ser atualizado</param>
        /// <returns>StatusCode(201)</returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
