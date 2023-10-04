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

        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                Clinica clinicaBuscada = _healthClinicContext.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

                if (clinicaBuscada != null)
                {
                    clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                    clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                    clinicaBuscada.Endereco = clinica.Endereco;
                    clinicaBuscada.HorarioAbertura = clinica.HorarioAbertura;
                    clinicaBuscada.HorarioEncerramento = clinica.HorarioEncerramento;
                }
                _healthClinicContext.Clinica.Update(clinicaBuscada!);

                _healthClinicContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthClinicContext.Add(clinica);

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
                Clinica clinicaBuscada = _healthClinicContext.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

                _healthClinicContext.Remove(clinicaBuscada);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            try
            {
                return _healthClinicContext.Clinica.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
