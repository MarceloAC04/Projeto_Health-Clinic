using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TiposUsuarioRepository()
        {
            _healthClinicContext= new HealthClinicContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                TiposUsuario tipoBuscado = _healthClinicContext.TiposUsuario.FirstOrDefault(t => t.IdTipoUsuario == id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.Titulo = tipoUsuario.Titulo;

                }

                _healthClinicContext.TiposUsuario.Update(tipoBuscado!);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuario = _healthClinicContext.TiposUsuario
                     .Select(t => new TiposUsuario
                     {
                         IdTipoUsuario = t.IdTipoUsuario,
                         Titulo = t.Titulo

                     }).FirstOrDefault(t => t.IdTipoUsuario == id)!;

                if (tipoUsuario != null)
                {
                    return tipoUsuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _healthClinicContext.Add(tipoUsuario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = _healthClinicContext.TiposUsuario.FirstOrDefault(t => t.IdTipoUsuario == id)!;

                _healthClinicContext.TiposUsuario.Remove(tipoBuscado);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposUsuario> Listar()
        {
            return _healthClinicContext.TiposUsuario.ToList();
        }
    }
}
