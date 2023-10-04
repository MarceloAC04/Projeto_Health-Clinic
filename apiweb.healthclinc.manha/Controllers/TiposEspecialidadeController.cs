using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEspecialidadeController : ControllerBase
    {
        private ITiposEspecialidadeRepository _tiposEspecialidadeRepository;

        public TiposEspecialidadeController()
        {
            _tiposEspecialidadeRepository = new TiposEspecialidadeRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastrar de um tipo de especialidade médica
        /// </summary>
        /// <param name="tiposEspecialidade">Tipo de especialidade a ser cadastrada</param>
        /// <returns>StatusCode(201) Success</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(TiposEspecialidade tiposEspecialidade)
        {
            try
            {
                _tiposEspecialidadeRepository.Cadastrar(tiposEspecialidade);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
