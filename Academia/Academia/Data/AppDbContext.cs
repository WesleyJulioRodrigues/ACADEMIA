using Academia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Academia.Data;

public class AppDbContext: IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Comida> Comidas { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Professor> Professores { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<Comida> comidas = new() {
            new() {
                Id = 1,
                Nome = "Batata Doce",
                Descricao = "A batata-doce é considerada uma fonte de carboidrato bastante saudável, rica em fibras, proteínas, vitaminas do complexo B, vitamina A, C e diferentes sais minerais. A presença de tantas vitaminas fortalece o sistema imunológico, enquanto os sais minerais ajudam a controlar a pressão arterial. É uma fonte de carboidrato complexo de lenta absorção, fornecendo muita energia durante treinos de alta intensidade",
                Foto = @"\imgs\"
            },
            new() {
                Id = 2,
                Nome = "Batata Doce",
                Descricao = "A batata-doce é considerada uma fonte de carboidrato bastante saudável, rica em fibras, proteínas, vitaminas do complexo B, vitamina A, C e diferentes sais minerais. A presença de tantas vitaminas fortalece o sistema imunológico, enquanto os sais minerais ajudam a controlar a pressão arterial. É uma fonte de carboidrato complexo de lenta absorção, fornecendo muita energia durante treinos de alta intensidade",
                Foto = @""
            },
        };
        builder.Entity<Comida>().HasData(comidas);


    }
}
