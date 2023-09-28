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
            try
            {
                Paciente pacienteBuscado = _healthClinicContext.Paciente.FirstOrDefault(p => p.IdPaciente == id)!;

                if (pacienteBuscado != null)
                {
                    pacienteBuscado.NomePaciente = paciente.NomePaciente;
                    pacienteBuscado.Idade = paciente.Idade;
                    pacienteBuscado.Telefone = paciente.Telefone;
                }

                _healthClinicContext.Paciente.Update(pacienteBuscado);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _healthClinicContext.Paciente
                    .Select(p => new Paciente
                    {
                        IdPaciente = p.IdPaciente,
                        NomePaciente = p.NomePaciente,
                        Idade = p.Idade,
                        CPF = p.CPF,
                        Telefone = p.Telefone,

                        IdUsuario = p.IdUsuario,
                        Usuario = new Usuario
                        {
                            IdUsuario= p.IdUsuario,
                            Email = p.Usuario!.Email,
                            Senha = p.Usuario!.Senha,
                            IdTipoUsuario = p.Usuario!.IdTipoUsuario,

                            TiposUsuario = new TiposUsuario
                            {
                                IdTipoUsuario = p.Usuario.IdTipoUsuario,
                                Titulo = p.Usuario.TiposUsuario!.Titulo
                            }
                        }
                    }).FirstOrDefault(p => p.IdPaciente == id)!;

                    if (pacienteBuscado != null)
                    {
                        return pacienteBuscado;
                    }
                    return null!;

            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                Paciente pacienteBuscado = _healthClinicContext.Paciente.FirstOrDefault(p => p.IdPaciente == id)!;

                _healthClinicContext.Remove(pacienteBuscado);

                _healthClinicContext.SaveChanges() ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Listar()
        {
            try
            {
                return _healthClinicContext.Paciente.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
