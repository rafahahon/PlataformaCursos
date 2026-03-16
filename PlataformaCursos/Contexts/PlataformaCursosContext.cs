using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domains;

namespace PlataformaCursos.Contexts;

public partial class PlataformaCursosContext : DbContext
{
    public PlataformaCursosContext()
    {
    }

    public PlataformaCursosContext(DbContextOptions<PlataformaCursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Aluno { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<Instrutor> Instrutor { get; set; }

    public virtual DbSet<Matricula> Matricula { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D03S30-1313845\\SQLEXPRESS;Database=PlataformaCursos;User Id=sa;Password=Senai@134;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.AlunoID).HasName("PK__Aluno__C1967C6F0155385B");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NomeAluno)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoID).HasName("PK__Curso__7E023A3729871F53");

            entity.Property(e => e.NomeCurso)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StatusCurso).HasDefaultValue(true);

            entity.HasOne(d => d.Instrutor).WithMany(p => p.Curso)
                .HasForeignKey(d => d.InstrutorID)
                .HasConstraintName("FK__Curso__Instrutor__06CD04F7");
        });

        modelBuilder.Entity<Instrutor>(entity =>
        {
            entity.HasKey(e => e.InstrutorID).HasName("PK__Instruto__096B84F4E882E7F5");

            entity.Property(e => e.Especializacao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeInstrutor)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.MatriculaID).HasName("PK__Matricul__908CEE22E44D5F31");

            entity.HasOne(d => d.Aluno).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.AlunoID)
                .HasConstraintName("FK__Matricula__Aluno__0B91BA14");

            entity.HasOne(d => d.Curso).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.CursoID)
                .HasConstraintName("FK__Matricula__Curso__0C85DE4D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
