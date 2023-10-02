using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;
using apiweb.healthclinc.manha.Utils;

namespace apiweb.healthclinc.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthClinicContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         Email = u.Email,
                         Senha = u.Senha,
                         IdTipoUsuario = u.IdTipoUsuario,

                         TiposUsuario = new TiposUsuario
                         {
                             IdTipoUsuario = u.IdTipoUsuario,
                             Titulo = u.TiposUsuario!.Titulo
                         }
                     }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;

                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuario = _healthClinicContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         Email = u.Email,
                         Senha = u.Senha,
                         IdTipoUsuario = u.IdTipoUsuario,

                         TiposUsuario = new TiposUsuario
                         {
                             IdTipoUsuario = u.IdTipoUsuario,
                             Titulo = u.TiposUsuario!.Titulo
                         }
                     }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuario != null)
                {
                    return usuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthClinicContext.Usuario.Add(usuario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
