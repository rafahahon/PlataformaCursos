namespace PlataformaCursos.DTOs.InstrutorDto
{
    public class CriarInstrutorDto
    {
        public int InstrutorID { get; set; }
        public string NomeInstrutor { get; set; } = null!;
        public string Especializacao { get; set; } = null!; 
    }
}
