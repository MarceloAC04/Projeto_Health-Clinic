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
        /// Endpoint que aciona o metodo de cadastrar um novo medico
        /// </summary>
        /// <param name="medico">Novo medico a ser cadastrado</param>
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
        /// Endpoint que aciona o metoodo de listar medicos
        /// </summary>
        /// <returns>retorna uma lista com todos os medicos cadastrados</returns>
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
        /// Endpoint que aciona o metodo de atualizar
        /// </summary>
        /// <param name="id">id do medico a ser atualizado</param>
        /// <param name="medico">corpo do medico a ser atualizado</param>
        /// <returns>StatusCode(201)</returns>
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
        /// Endpoint que aciona o metodo de deletar um medico
        /// </summary>
        /// <param name="id">Id do medico a ser deletado</param>
        /// <returns>StatusCode(201)</returns>
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
        /// Endpoint que aciona o metodo de buscar por id de um medico
        /// </summary>
        /// <param name="id">Id do medico a ser buscado</param>
        /// <returns>Retorna o medico encontrado</returns>
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
