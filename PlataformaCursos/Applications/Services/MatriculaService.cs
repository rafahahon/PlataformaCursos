using PlataformaCursos.Domains;
using PlataformaCursos.DTOs.MatriculaDto;
using PlataformaCursos.Exceptions;
using PlataformaCursos.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PlataformaCursos.Applications.Services
{
    public class MatriculaService
    {
            private readonly IMatriculaRepository _repository;

            public MatriculaService(IMatriculaRepository repository)
            {
                _repository = repository;
            }

            private static LerMatriculaDto LerDto(Matricula matricula)
            {
                LerMatriculaDto LerMatricula = new LerMatriculaDto()
                {
                    MatriculaID = matricula.MatriculaID,
                    AlunoID = matricula.AlunoID,
                    CursoID = matricula.CursoID
                };

                return LerMatricula;
            }

            public List<LerMatriculaDto> Listar()
            {
                List<Matricula> matriculas = _repository.Listar();

                List<LerMatriculaDto> matriculasDto = matriculas.Select(matriculaBanco => LerDto(matriculaBanco)).ToList();

                return matriculasDto;
            }

            public LerMatriculaDto ObterPorId(int id)
            {
                Matricula? matricula = _repository.ObterPorId(id);

                if (matricula == null)
                {
                    throw new DomainException("Matrícula não existe.");
                }

                return LerDto(matricula);
            }

            public LerMatriculaDto Adicionar(CriarMatriculaDto matriculaDto)
            {
                Matricula matricula = new Matricula
                {
                    AlunoID = matriculaDto.AlunoID,
                    CursoID = matriculaDto.CursoID
                };

                _repository.Adicionar(matricula);

                return LerDto(matricula);
            }

            public void Remover(int id)
            {
                Matricula matricula = _repository.ObterPorId(id);

                if (matricula == null)
                {
                    throw new DomainException("Matrícula não encontrado.");
                }

                _repository.Remover(id);
            }
    }
}
