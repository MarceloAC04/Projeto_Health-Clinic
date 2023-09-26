using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Paciente paciente);

        Paciente BuscarPorId(Guid id);

        void Atualizar(Guid id, Paciente paciente);
    }
}
