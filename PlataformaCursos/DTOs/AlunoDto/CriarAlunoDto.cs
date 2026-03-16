namespace PlataformaCursos.DTOs.AlunoDto
{
    public class CriarAlunoDto
    {
        public int AlunoID { get; set; }
        public string NomeAluno { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
