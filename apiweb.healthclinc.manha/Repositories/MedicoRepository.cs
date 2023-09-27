using apiweb.healthclinc.manha.Contexts;
using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Interfaces;

namespace apiweb.healthclinc.manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public MedicoRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            try
            {
                Medico medicoBuscado = _healthClinicContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;

                if (medicoBuscado != null)
                {
                    medicoBuscado.NomeMedico = medico.NomeMedico;
                    medicoBuscado.CRM = medico.CRM;
                    medicoBuscado.IdEspecialidade = medico.IdEspecialidade;

                }

                _healthClinicContext.Medico.Update(medicoBuscado!);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medico = _healthClinicContext.Medico
                     .Select(m => new Medico
                     {
                         IdMedico = m.IdMedico,
                         NomeMedico= m.NomeMedico,
                         CRM = m.CRM,
                         IdUsuario = m.IdUsuario,

                         Usuario = new Usuario
                         {
                             IdUsuario = m.IdUsuario,
                             Email = m.Usuario!.Email,
                             Senha = m.Usuario!.Senha,
                             IdTipoUsuario = m.Usuario!.IdTipoUsuario,

                             TiposUsuario = new TiposUsuario
                             {
                                 IdTipoUsuario = m.Usuario.IdTipoUsuario,
                                 Titulo = m.Usuario.TiposUsuario!.Titulo  
                             }
                         },

                         TipoEspecialidade = new TiposEspecialidade
                         {
                             IdTipoEspecialidade = m.IdEspecialidade,
                             Especialidade = m.TipoEspecialidade!.Especialidade
                         },

                         IdClinica = m.IdClinica,
                         Clinca = new Clinica
                         {
                             IdClinica = m.IdClinica,
                             NomeFantasia = m.Clinca!.NomeFantasia,
                             CNPJ = m.Clinca!.CNPJ,
                             RazaoSocial = m.Clinca!.RazaoSocial,
                             Endereco = m.Clinca!.Endereco,
                         }

                        
                     }).FirstOrDefault(m => m.IdMedico == id)!;

                if (medico != null)
                {
                    return medico;
                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthClinicContext.Add(medico);

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
               Medico medicoBuscado = _healthClinicContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;

               _healthClinicContext.Remove(medicoBuscado);
                
               _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medico> Listar()
        {
            return _healthClinicContext.Medico.ToList();
        }
    }
}
