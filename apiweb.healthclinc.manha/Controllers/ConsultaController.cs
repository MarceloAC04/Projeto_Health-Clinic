using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ConsultasDoMedico")]
        public IActionResult MedicoConsultas(Guid id)
        {
            try
            {
                List<Consulta> ListaMedico = _consultaRepository.ListarMinhasMedico(id);

                return Ok(ListaMedico);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        } 
        [HttpGet("ConsultasDoPaciente")]
        public IActionResult PacienteConsultas(Guid id)
        {
            try
            {
                List<Consulta> ListaPaciente = _consultaRepository.ListarMinhasPaciente(id);

                return Ok(ListaPaciente);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("Consultas")]
        public IActionResult Listar()
        {
            try
            {
                List<Consulta> Lista = _consultaRepository.Listar();

                return Ok(Lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
