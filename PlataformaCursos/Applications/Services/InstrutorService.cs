using PlataformaCursos.Domains;
using PlataformaCursos.DTOs.AlunoDto;
using PlataformaCursos.DTOs.InstrutorDto;
using PlataformaCursos.Exceptions;
using PlataformaCursos.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PlataformaCursos.Applications.Services
{
    public class InstrutorService
    {
        private readonly IInstrutorRepository _repository;

        public InstrutorService(IInstrutorRepository repository)
        {
            _repository = repository;
        }

        private static LerInstrutorDto LerDto(Instrutor instrutor ) 
        {
            LerInstrutorDto LerInstrutor = new LerInstrutorDto()
            {
                InstrutorID = instrutor.InstrutorID,
                NomeInstrutor = instrutor.NomeInstrutor,
                Especializacao = instrutor.Especializacao
            };

            return LerInstrutor;
        }

        public List<LerInstrutorDto> Listar()
        {
            List<Instrutor> instrutores = _repository.Listar();

            List<LerInstrutorDto> instrutoresDto = instrutores.Select(instrutorBanco => LerDto(instrutorBanco)).ToList();

            return instrutoresDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        public LerInstrutorDto ObterPorId(int id)
        {
            Instrutor? instrutor = _repository.ObterPorId(id);

            if (instrutor == null)
            {
                throw new DomainException("Instrutor não existe.");
            }

            return LerDto(instrutor);  
        }

        public LerInstrutorDto Adicionar(CriarInstrutorDto instrutorDto)
        {
            ValidarNome(instrutorDto.NomeInstrutor);

            Instrutor instrutor = new Instrutor 
            {
                NomeInstrutor = instrutorDto.NomeInstrutor,
                Especializacao = instrutorDto.Especializacao
            };

            _repository.Adicionar(instrutor); 

            return LerDto(instrutor); 
        }

        public LerInstrutorDto Atualizar(int id, CriarInstrutorDto instrutorDto)
        {
            ValidarNome(instrutorDto.NomeInstrutor);

            Instrutor instrutorBanco = _repository.ObterPorId(id);

            if (instrutorBanco == null)
            {
                throw new DomainException("Instrutor não encontrado.");
            }

            instrutorBanco.NomeInstrutor = instrutorDto.NomeInstrutor;
            instrutorBanco.Especializacao = instrutorDto.Especializacao;

            _repository.Atualizar(instrutorBanco);

            return LerDto(instrutorBanco);
        }

        public void Remover(int id)
        {
            Instrutor instrutor = _repository.ObterPorId(id);

            if (instrutor == null)
            {
                throw new DomainException("Instrutor não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
