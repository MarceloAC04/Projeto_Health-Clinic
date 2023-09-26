using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> ListarMinhas(Guid id);

        Consulta BuscarPorId(Guid id);

        void Atualizar(Guid id,Consulta consulta);
    }
}
