using PlataformaCursos.Domains;

namespace PlataformaCursos.Interfaces
{
    public interface IInstrutorRepository
    {
        List<Instrutor> Listar();

        Instrutor? ObterPorId(int id);

        void Adicionar(Instrutor instrutor);

        void Atualizar(Instrutor instrutor);

        void Remover(int id);
    }
}
