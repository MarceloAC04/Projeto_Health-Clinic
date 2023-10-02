using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }
        
        /// <summary>
        /// Endpoint que aciona o método de cadastrar um novo médico
        /// </summary>
        /// <param name="medico">Novo médico a ser cadastrado</param>
        /// <returns>StatusCode(201) sucess</returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de listar médicos
        /// </summary>
        /// <returns>retorna uma lista com todos os médicos cadastrados</returns>
        [HttpGet("Listar Médicos")]
        public IActionResult Listar()
        {
            try
            {
                List<Medico> lista = _medicoRepository.Listar();

                return Ok(lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint que aciona o método de atualizar
        /// </summary>
        /// <param name="id">id do médico a ser atualizado</param>
        /// <param name="medico">corpo do médico a ser atualizado</param>
        /// <returns>StatusCode(201) sucess</returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, Medico medico) 
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de deletar um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        /// <returns>StatusCode(201) sucess</returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id) 
        {
            try
            {
                _medicoRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de buscar por id de um médico
        /// </summary>
        /// <param name="id">Id do médico a ser buscado</param>
        /// <returns>Retorna o médico encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            try
            {
               Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

                return Ok(medicoBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
