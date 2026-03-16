using PlataformaCursos.Contexts;
using PlataformaCursos.Domains;
using PlataformaCursos.Interfaces;
using static PlataformaCursos.Repositories.AlunoRepository;

namespace PlataformaCursos.Repositories
{
     public class AlunoRepository : IAlunoRepository
        {
            private readonly PlataformaCursosContext _context;

            public AlunoRepository(PlataformaCursosContext context)
            {
                _context = context;
            }

            public List<Aluno> Listar()
            {
                return _context.Aluno.ToList();
            }

            public Aluno? ObterPorId(int id)
            {
                return _context.Aluno.Find(id);
            }

            public Aluno? ObterPorEmail(string email)
            {
                return _context.Aluno.FirstOrDefault(usuario => usuario.Email == email);
            }

            public bool EmailExiste(string email)
            {
                return _context.Aluno.Any(usuario => usuario.Email == email);
            }

            public void Adicionar(Aluno usuario)
            {
                _context.Aluno.Add(usuario);
                _context.SaveChanges();
            }

            public void Atualizar(Aluno aluno)
            {
                Aluno? alunoBanco = _context.Aluno.FirstOrDefault(alunoAux => alunoAux.AlunoID == aluno.AlunoID);

                if (alunoBanco == null)
                {
                    return;
                }

                alunoBanco.NomeAluno = aluno.NomeAluno;
                alunoBanco.Email = aluno.Email;

                _context.SaveChanges();
            }

            public void Remover(int id)
            {                      
                Aluno? aluno = _context.Aluno.FirstOrDefault(alunoAux => alunoAux.AlunoID == id);

                if (aluno == null)
                {
                    return;
                }

                _context.Aluno.Remove(aluno);
                _context.SaveChanges();
            }
    }
}
