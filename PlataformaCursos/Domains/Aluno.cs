using System;
using System.Collections.Generic;

namespace PlataformaCursos.Domains;

public partial class Aluno
{
    public int AlunoID { get; set; }

    public string NomeAluno { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Matricula> Matricula { get; set; } = new List<Matricula>();
}
