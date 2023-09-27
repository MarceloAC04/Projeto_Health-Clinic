using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthClinicContext.Add(paciente);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
