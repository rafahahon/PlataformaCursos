using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Contexts;
using PlataformaCursos.Domains;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly PlataformaCursosContext _context;

        public MatriculaRepository(PlataformaCursosContext context)
        {
            _context = context;
        }

        public List<Matricula> Listar()
        {
            List<Matricula> matriculas = _context.Matricula.Include(matricula => matricula.AlunoID)
                .Include(matricula => matricula.CursoID)
                .ToList();

            return matriculas;
        }

        public Matricula ObterPorId(int id)
        {
            Matricula? matricula = _context.Matricula
                .Include(matriculaDb => matriculaDb.AlunoID)
                .Include(matriculaDb => matriculaDb.CursoID)
                .FirstOrDefault(matriculaDb => matriculaDb.MatriculaID == id);

            return matricula;
        }

        public void Adicionar(Matricula matricula)
        {

            _context.Matricula.Add(matricula);
            _context.SaveChanges();
        }

        public void Atualizar(Matricula matricula)
        {
            Matricula? matriculaBanco = _context.Matricula.FirstOrDefault(m => m.MatriculaID == matricula.MatriculaID);

            if (matriculaBanco == null)
            {
                return;
            }

            matriculaBanco.AlunoID = matricula.AlunoID;
            matriculaBanco.CursoID = matricula.CursoID;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Matricula? matricula = _context.Matricula.FirstOrDefault(m => m.MatriculaID == id);

            if (matricula == null)
            {
                return;
            }

            _context.Matricula.Remove(matricula);
            _context.SaveChanges();
        }
    }
}
