using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Endpoint que aciona um método cadastrar de uma nova consulta
        /// </summary>
        /// <param name="consulta">consulta a ser cadastrada</param>
        /// <returns>StatusCode(201) Success</returns>
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

        /// <summary>
        /// Endpoint que aciona o método listar consultas de um médico
        /// </summary>
        /// <param name="id">Id do médico de referência para a listagem das consulta</param>
        /// <returns>Retorna uma lista com as consultas do médico</returns>
        [HttpGet("ConsultasDoMedico")]
        //[Authorize(Roles = "Medico")]
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

        /// <summary>
        /// Endpoint que aciona o método listar consultas de um paciente
        /// </summary>
        /// <param name="id">Id do paciente de referência para a listagem das consulta</param>
        /// <returns>Retorna uma lista com as consultas do paciente</returns>
        [HttpGet("ConsultasDoPaciente")]
        //[Authorize(Roles = "Paciente")]
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
        /// <summary>
        /// Endpoint que aciona o método de listar de todas as consultas
        /// </summary>
        /// <returns>Retorna uma lista de todas as consultas</returns>
        [HttpGet("Consultas")]
        //[Authorize(Roles = "Administrador")]
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

        /// <summary>
        /// Endpoint que aciona o método de buscar por id de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser buscada</param>
        /// <returns>retorna a consulta buscada</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarId(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método atualizar de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="consulta">Corpo da consulta a ser atualizada</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, Consulta consulta) 
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
