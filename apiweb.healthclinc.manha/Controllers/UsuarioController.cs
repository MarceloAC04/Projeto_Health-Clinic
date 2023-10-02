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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">Novo usuário a ser cadastrado</param>
        /// <returns>StatusCode(201) sucess </returns>
        [HttpPost]
       // [Authorize(Roles = "Administrador")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método buscar por id de um usuário cadastrado
        /// </summary>
        /// <param name="id">Id do usuário a ser buscado</param>
        /// <returns>Retorna o usuário encontrado</returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método buscar por email e senha de um usuário
        /// </summary>
        /// <param name="email">Email do usuário a ser buscado</param>
        /// <param name="senha">Senha do usuário a ser buscado</param>
        /// <returns>Retorna o usuário encontrado</returns>
        [HttpGet("EmaileSenha")]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
