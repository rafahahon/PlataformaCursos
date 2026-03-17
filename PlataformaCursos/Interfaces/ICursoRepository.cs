using PlataformaCursos.Domains;

namespace PlataformaCursos.Interfaces
{
    public interface ICursoRepository
    {
        List<Curso> Listar();

        Curso? ObterPorId(int id);
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
        void Remover(int id);
    }
}
