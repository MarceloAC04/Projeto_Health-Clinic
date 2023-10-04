using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Endpoint que aciona o método de cadastrar no repositório da clínica
        /// </summary>
        /// <param name="clinica">nova clinica a ser cadastrada</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de deletar uma clínica
        /// </summary>
        /// <param name="id">Id da clínica a ser deletada</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        /// <summary>
        /// Endpoint que aciona método de listar todas as clínicas cadastradas
        /// </summary>
        /// <returns>Retorna uma lista contendo todas as clínicas cadastradas</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Lista()
        {
            try
            {
                List<Clinica> lista = _clinicaRepository.Listar();

                return Ok(lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de atualizar uma clínica 
        /// </summary>
        /// <param name="id">Id da clínica a ser atualizada</param>
        /// <param name="clinica">Corpo da clínica a ser atualizada</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Atualizar (Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
