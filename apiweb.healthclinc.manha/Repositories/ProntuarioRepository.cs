using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ProntuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                Prontuario prontuarioBuscado = _healthClinicContext.Prontuario.FirstOrDefault(p => p.IdProntuario == id)!;

                if (prontuarioBuscado != null)
                {
                    prontuarioBuscado.DescricaoProntuario = prontuario.DescricaoProntuario;
                }

                _healthClinicContext.Prontuario.Update(prontuarioBuscado!);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = _healthClinicContext.Prontuario
                    .Select(p => new Prontuario
                    {
                        IdProntuario = p.IdProntuario,
                        DescricaoProntuario = p.DescricaoProntuario,

                        IdPaciente = p.IdPaciente,

                        Paciente = new Paciente
                        {
                            IdPaciente = p.IdPaciente,
                            NomePaciente = p.Paciente!.NomePaciente,
                            CPF = p.Paciente.CPF,
                            Idade = p.Paciente!.Idade
                        },

                        IdMedico = p.IdMedico,
                        Medico = new Medico
                        {
                            IdMedico = p.IdMedico,
                            NomeMedico = p.Medico!.NomeMedico,
                            TipoEspecialidade = p.Medico.TipoEspecialidade
                        }


                    }).FirstOrDefault(p => p.IdProntuario == id)!;
                if (prontuarioBuscado != null)
                {
                    return prontuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                _healthClinicContext.Add(prontuario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
