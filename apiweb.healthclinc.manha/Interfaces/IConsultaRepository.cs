using apiweb.healthclinc.manha.Domains;
using apiweb.healthclinc.manha.Repositories;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> ListarMinhasMedico(Guid id); 
        List<Consulta> ListarMinhasPaciente(Guid id);
        List<Consulta> Listar();

        Consulta BuscarPorId(Guid id);

        void Atualizar(Guid id,Consulta consulta);
    }
}
