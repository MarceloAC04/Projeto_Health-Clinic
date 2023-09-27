using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        Medico BuscarPorId(Guid id);

        void Atualizar(Guid id, Medico medico);

        List<Medico> Listar();
    }
}
