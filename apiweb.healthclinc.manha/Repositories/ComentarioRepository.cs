using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ComentarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public Comentario BuscarPorId(Guid id)
        {
            try
            {
               Comentario comentarioBuscado = _healthClinicContext.Comentario
                    .Select(c => new Comentario
                    {
                        IdComentario = c.IdComentario,
                        DescricaoComentario= c.DescricaoComentario,

                        IdPaciente = c.IdPaciente,
                        Paciente = new Paciente
                        {
                            IdPaciente = c.IdPaciente,
                            NomePaciente = c.Paciente!.NomePaciente
                        },

                        IdClinica = c.IdClinica,
                        Clinica = new Clinica
                        {
                            IdClinica= c.IdClinica,
                            NomeFantasia = c.Clinica!.NomeFantasia
                        }

                    }).FirstOrDefault(c => c.IdComentario == id)!;

                if (comentarioBuscado != null)
                {
                    return comentarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _healthClinicContext.Add(comentario);

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
                Comentario comentarioBuscado = _healthClinicContext.Comentario.FirstOrDefault(c => c.IdComentario == id)!;

                _healthClinicContext.Remove(comentarioBuscado);

                _healthClinicContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentario> Listar()
        {
            try
            {
                return  _healthClinicContext.Comentario
                    .Select(c => new Comentario
                    {
                        IdComentario = c.IdComentario,
                        DescricaoComentario = c.DescricaoComentario,
                        Exibe = c.Exibe,
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
                    }).Where(c => c.Exibe == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
