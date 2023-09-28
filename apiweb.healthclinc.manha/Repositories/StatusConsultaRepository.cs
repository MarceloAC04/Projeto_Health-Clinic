using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Interfaces;
using Microsoft.IdentityModel.Logging;

namespace apiweb.healthclinc.manha.Repositories
{
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public StatusConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Cadastrar(Domains.StatusConsulta statusConsulta)
        {
            try
            {
                _healthClinicContext.Add(statusConsulta);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
