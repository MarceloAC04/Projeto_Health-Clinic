using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Repositories;
using apiweb.healthclinc.manha.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace apiweb.healthclinc.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        /// <summary>
        /// Endpoint que aciona o metodo de login da api e que gera o token de acesso
        /// </summary>
        /// <param name="usuario">dados do usuario a ser logado</param>
        /// <returns>token de acesso gerado</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                //Cria um objeto que recebe os dados da requisicao
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário ou Senha Inválidos");
                }

                //Caso encontre o usuário, prossegue para criação do token

                //1) - Defini as informações(claims) que serão fornecidas no token(PAYLOAD)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario.Titulo),


                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                //2) - Defini a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-chave-autenticacao-webapi-dev"));


                //3) - Defini as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4) - Gerar o token 
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "healthclinic.webApi",

                    //Destinatario de token
                    audience: "healthclinic.webApi",

                    //dados definidos nas claims(Informações)
                    claims: claims,

                    //tempo de expiração de token
                    expires: DateTime.Now.AddMinutes(5),

                    //credencias do token
                    signingCredentials: creds
                );

                //5) - Retorna o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }
    }
}
