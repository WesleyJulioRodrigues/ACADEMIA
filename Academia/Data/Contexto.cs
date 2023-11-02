using System.ComponentModel.DataAnnotations;
using Academia.Data;
using Professor.Models;
using ComidaRecomendada.Models;

namespace Academia.Data;
public class Contexto : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ComidaRecomendada> ComidasRecomendadas { get; set; }
    public DbSet<Professor> Professores { get; set;}

    protected override void OnModelCreating(ModelBuilder builder) //void não tem retorno
    {
        base.OnModelCreating(builder);
        AppDbSeed appDbSeed = new(builder);

        //FluentAPI

        #region Many To Many - ComidaRecomendada
        builder.Entity<ComidaRecomendada>()
            .HasOne(cr => cr.Professor)
            .WithMany(p => p.ComidasRecomendadas)
            .HasForeignKey(cr => cr.ProfessorId);

        builder.Entity<ComidaRecomendada>()
            .HasOne(cr => cr.Aluno)
            .WithMany(a => a.ComidasRecomendadas)
            .HasForeignKey(cr => cr.AlunoId);
        #endregion

    }
}
