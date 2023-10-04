using apiweb.healthclinc.manha.Domains;

namespace apiweb.healthclinc.manha.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        List<Clinica> Listar();

        void Atualizar(Guid id , Clinica clinica);
    }
}
