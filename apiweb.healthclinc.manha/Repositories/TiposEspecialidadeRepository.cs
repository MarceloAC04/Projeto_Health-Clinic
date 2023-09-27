using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class TiposEspecialidadeRepository : ITiposEspecialidadeRepository
    {

        private readonly HealthClinicContext _healthClinicContext;

        public TiposEspecialidadeRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Cadastrar(TiposEspecialidade tiposEspecialidade)
        {
            try
            {
                _healthClinicContext.Add(tiposEspecialidade);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
