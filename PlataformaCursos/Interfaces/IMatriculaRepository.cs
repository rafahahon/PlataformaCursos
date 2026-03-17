using PlataformaCursos.Domains;

namespace PlataformaCursos.Interfaces
{
    public interface IMatriculaRepository
    {
        List<Matricula> Listar();
        Matricula? ObterPorId(int id);
        void Adicionar(Matricula matricula);
        void Remover(int id);
    }
}
