using PlataformaCursos.Contexts;
using PlataformaCursos.Domains;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly PlataformaCursosContext _context;

        public CursoRepository(PlataformaCursosContext context)
        {
            _context = context;
        }

        public List<Curso> Listar()
        {
            return _context.Curso.ToList();
        }

        public Curso? ObterPorId(int id)
        {
            return _context.Curso.Find(id);
        }

        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
            _context.SaveChanges();
        }

        public void Atualizar(Curso curso)
        {
            Curso? cursoBanco = _context.Curso.FirstOrDefault(cursoAux => cursoAux.CursoID == curso.CursoID);

            if (cursoBanco == null)
            {
                return;
            }

            cursoBanco.NomeCurso = curso.NomeCurso;
            cursoBanco.CargaHoraria = curso.CargaHoraria;
            cursoBanco.StatusCurso = curso.StatusCurso;
            cursoBanco.InstrutorID = curso.InstrutorID;
            

            _context.SaveChanges();
        }   

        public void Remover(int id)
        {
            Curso? curso = _context.Curso.FirstOrDefault(cursoAux => cursoAux.CursoID == id);

            if (curso == null)
            {
                return;
            }

            _context.Curso.Remove(curso);
            _context.SaveChanges();
        }
    }
}
