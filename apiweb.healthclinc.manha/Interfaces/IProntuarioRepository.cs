using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);

        void Deletar(Prontuario prontuario);

        Prontuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Prontuario prontuario);
    }
}
