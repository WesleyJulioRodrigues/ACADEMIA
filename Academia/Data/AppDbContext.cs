using Microsoft.EntityFrameworkCore;
using Academia.Models;

namespace Academia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ComidaRecomendada> ComidasRecomendadas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        // outras definições de DbSet e configurações do banco de dados
    }
}