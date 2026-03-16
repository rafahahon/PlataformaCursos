using PlataformaCursos.Domains;
using PlataformaCursos.DTOs.AlunoDto;
using PlataformaCursos.Exceptions;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Applications.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        private static LerAlunoDto LerDto(Aluno aluno)
        {
            LerAlunoDto LerAluno = new LerAlunoDto()
            {
                AlunoID = aluno.AlunoID,
                NomeAluno = aluno.NomeAluno,
                Email = aluno.Email
            };

            return LerAluno;
        }

        public List<LerAlunoDto> Listar()
        {
            List<Aluno> alunos = _repository.Listar();
            List<LerAlunoDto> alunosDto = alunos.Select(aluno => LerDto(aluno)).ToList();
            return alunosDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new DomainException("Email inválido.");
            }
        }

        public LerAlunoDto ObterPorId(int id)
        {
            Aluno? aluno = _repository.ObterPorId(id);

            if (aluno == null)
            {
                throw new DomainException("Aluno não existe.");
            }

            return LerDto(aluno); 
        }

        public LerAlunoDto ObterPorEmail(string email)
        {
            Aluno? aluno = _repository.ObterPorEmail(email);

            if (aluno == null)
            {
                throw new DomainException("Usuário não existe.");
            }

            return LerDto(aluno);  
        }

        public LerAlunoDto Adicionar(CriarAlunoDto alunoDto)
        {
            ValidarEmail(alunoDto.Email);
            ValidarNome(alunoDto.NomeAluno);

            if (_repository.EmailExiste(alunoDto.Email))
            {
                throw new DomainException("Já existe um aluno com este e-mail.");
            }

            Aluno aluno = new Aluno 
            {
                NomeAluno = alunoDto.NomeAluno,
                Email = alunoDto.Email,
            };

            _repository.Adicionar(aluno); 

            return LerDto(aluno); 
        }


        public LerAlunoDto Atualizar(int id, CriarAlunoDto alunoDto)
        {
            ValidarEmail(alunoDto.Email);
            ValidarNome(alunoDto.NomeAluno);

            Aluno alunoBanco = _repository.ObterPorId(id);

            if (alunoBanco == null)
            {
                throw new DomainException("Aluno não encontrado.");
            }

            ValidarEmail(alunoDto.Email);

            Aluno alunoComMesmoEmail = _repository.ObterPorEmail(alunoDto.Email);

            if (alunoComMesmoEmail != null && alunoComMesmoEmail.AlunoID != id)
            {
                throw new DomainException("Já existe um aluno com este email.");
            }

            alunoBanco.Email = alunoDto.Email;

            _repository.Atualizar(alunoBanco);

            return LerDto(alunoBanco);
        }

        public void Remover(int id)
        {
            Aluno aluno = _repository.ObterPorId(id);

            if (aluno == null)
            {
                throw new DomainException("Aluno não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
