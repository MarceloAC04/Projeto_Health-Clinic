using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscado = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;

                if (consultaBuscado != null)
                {
                    consultaBuscado.DataConsulta = consulta.DataConsulta;
                    consultaBuscado.Horario = consulta.Horario;
                    consultaBuscado.IdStatusConsulta = consulta.IdStatusConsulta;
                }

                _healthClinicContext.Consulta.Update(consultaBuscado!);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _healthClinicContext.Consulta
                    .Select(c => new Consulta
                    {
                        IdConsulta = c.IdConsulta,
                        DataConsulta = c.DataConsulta,
                        Horario = c.Horario,
                        Descricao = c.Descricao,

                        IdStatusConsulta = c.IdStatusConsulta,
                        StatusConsulta = new StatusConsulta
                        {
                            IdStatusConsulta = c.IdStatusConsulta,
                            Status = c.StatusConsulta!.Status
                        },

                        IdMedico = c.IdMedico,

                        Medico = new Medico
                        {
                            IdMedico = c.IdMedico,
                            NomeMedico = c.Medico!.NomeMedico
                        },

                        IdPaciente = c.IdPaciente,

                        Paciente = new Paciente
                        {
                            IdPaciente = c.IdPaciente,
                            NomePaciente = c.Paciente!.NomePaciente
                        },

                        IdClinica = c.IdClinica,

                        Clinica = new Clinica
                        {
                            IdClinica = c.IdClinica,
                            NomeFantasia = c.Clinica!.NomeFantasia
                        }   
                    }).FirstOrDefault(c => c.IdConsulta == id)!;
                if (consultaBuscada != null)
                {
                    return consultaBuscada;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthClinicContext.Add(consulta);

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
                Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasMedico(Guid id)
        {
            return _healthClinicContext.Consulta.Where(c => c.IdMedico == id).ToList();
        }

        public List<Consulta> ListarMinhasPaciente(Guid id)
        {
            return _healthClinicContext.Consulta.Where(c => c.IdPaciente == id).ToList();
        }

        public List<Consulta> Listar()
        {
            return _healthClinicContext.Consulta.ToList();
        }
    }
}
