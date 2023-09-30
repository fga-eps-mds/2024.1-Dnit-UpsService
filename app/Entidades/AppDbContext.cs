using Entidades;
using Microsoft.EntityFrameworkCore;

namespace app.Entidades
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuracao;

        public DbSet<Sinistro> Sinistros { get; set; }

        public AppDbContext(IConfiguration configuracao)
        {
            this.configuracao = configuracao;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuracao.GetConnectionString("PostgreSql"));
        }
    }
}