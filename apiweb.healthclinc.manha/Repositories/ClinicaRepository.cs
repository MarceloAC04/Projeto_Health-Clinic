using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Cadastrar(Clinica clinica)
        {
            _healthClinicContext.Add(clinica);
        }
    }
}
