using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Medico medico);

        Medico BuscarPorId(Guid id);

        void Atualizar(Guid id, Medico medico);
    }
}
