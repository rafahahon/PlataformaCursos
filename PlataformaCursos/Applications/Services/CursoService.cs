using PlataformaCursos.Domains;
using PlataformaCursos.DTOs.CursoDto;
using PlataformaCursos.Exceptions;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Applications.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        private static LerCursoDto LerDto(Curso curso)
        {
            LerCursoDto LerCurso = new LerCursoDto()
            {
                CursoID = curso.CursoID,
                NomeCurso = curso.NomeCurso,
                CargaHoraria = curso.CargaHoraria,
                InstrutorID = curso.InstrutorID,
                StatusCurso = curso.StatusCurso 
            };

            return LerCurso;
        }

        public List<LerCursoDto> Listar()
        {
            List<Curso> cursos = _repository.Listar();

            List<LerCursoDto> cursosDto = cursos.Select(cursoBanco => LerDto(cursoBanco)).ToList();

            return cursosDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        public LerCursoDto ObterPorId(int id)
        {
            Curso? curso = _repository.ObterPorId(id);

            if (curso == null)
            {
                throw new DomainException("Curso não existe.");
            }

            return LerDto(curso);
        }

        public LerCursoDto Adicionar(CriarCursoDto cursoDto)
        {
            ValidarNome(cursoDto.NomeCurso);

            Curso curso = new Curso
            {
                NomeCurso = cursoDto.NomeCurso,
                CargaHoraria = cursoDto.CargaHoraria,
                InstrutorID = cursoDto.InstrutorID,
                StatusCurso = true
            };

            _repository.Adicionar(curso);

            return LerDto(curso); 
        }

        public LerCursoDto Atualizar(int id, CriarCursoDto cursoDto)
        {
            ValidarNome(cursoDto.NomeCurso);

            Curso cursoBanco = _repository.ObterPorId(id);

            if (cursoBanco == null)
            {
                throw new DomainException("Curso não encontrado.");
            }

            cursoBanco.NomeCurso = cursoDto.NomeCurso;
            cursoBanco.CargaHoraria = cursoDto.CargaHoraria;
            cursoBanco.InstrutorID = cursoDto.InstrutorID;

            _repository.Atualizar(cursoBanco);

            return LerDto(cursoBanco);
        }

        public void Remover(int id)
        {
            Curso curso = _repository.ObterPorId(id);

            if (curso == null)
            {
                throw new DomainException("Curso não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
