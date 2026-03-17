namespace PlataformaCursos.DTOs.CursoDto
{
    public class LerCursoDto
    {
        public int CursoID { get; set; }
        public string NomeCurso { get; set; } = null!;
        public int CargaHoraria { get; set; }
        public int? InstrutorID { get; set; }
        public bool? StatusCurso { get; set; }
    }
}
