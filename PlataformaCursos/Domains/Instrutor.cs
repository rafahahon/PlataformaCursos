using System;
using System.Collections.Generic;

namespace PlataformaCursos.Domains;

public partial class Instrutor
{
    public int InstrutorID { get; set; }

    public string NomeInstrutor { get; set; } = null!;

    public string Especializacao { get; set; } = null!;

    public virtual ICollection<Curso> Curso { get; set; } = new List<Curso>();
}
