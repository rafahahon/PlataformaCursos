namespace PlataformaCursos.DTOs.CursoDto
{
    public class CriarCursoDto
    {
        public string NomeCurso { get; set; } = null!;
        public int CargaHoraria { get; set; }
        public int InstrutorID { get; set; }
    }
}
