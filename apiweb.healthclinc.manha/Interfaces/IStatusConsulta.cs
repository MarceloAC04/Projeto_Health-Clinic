using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IStatusConsulta
    {
        void Cadastrar(StatusConsulta statusConsulta);

        void Deletar(StatusConsulta statusConsulta);

        StatusConsulta BuscarPorId(Guid id);

        void Atualizar(Guid id, StatusConsulta statusConsulta);
    }
}
