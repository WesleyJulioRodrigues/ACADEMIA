using Microsoft.EntityFrameworkCore;
using Academia.Models;

namespace academia.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<ComidaRecomendada> ComidasRecomendadas { get; set; }

        // Adicione outras DbSet e configurações de banco de dados conforme necessário
    }
}