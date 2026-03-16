using PlataformaCursos.Contexts;
using PlataformaCursos.Domains;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Repositories
{
    public class InstrutorRepository : IInstrutorRepository
    {
        private readonly PlataformaCursosContext _context;

        public InstrutorRepository(PlataformaCursosContext context)
        {
            _context = context;
        }

        public List<Instrutor> Listar()
        {
            return _context.Instrutor.ToList();
        }

        public Instrutor? ObterPorId(int id)
        {
            return _context.Instrutor.Find(id);
        }

        public void Adicionar(Instrutor instrutor)
        {
            _context.Instrutor.Add(instrutor);
            _context.SaveChanges();
        }

        public void Atualizar(Instrutor instrutor)
        {
            Instrutor? instrutorBanco = _context.Instrutor.FirstOrDefault(usuarioAux => usuarioAux.UsuarioID == usuario.UsuarioID);

            if (instrutorBanco == null)
            {
                return;
            }

            instrutorBanco.NomeInstrutor = instrutor.NomeInstrutor;
            instrutorBanco.Especializacao = instrutor.Especializacao;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {                                                       
            Instrutor? instrutor = _context.Instrutor.FirstOrDefault(instrutorAux => instrutorAux.InstrutorID == id);

            if (instrutor == null)
            {
                return;
            }

            _context.Instrutor.Remove(instrutor);
            _context.SaveChanges();
        }
    }
}
