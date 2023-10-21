using Entidades;
using Microsoft.EntityFrameworkCore;

namespace app.Entidades
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sinistro> Sinistros { get; set; }
        public DbSet<Rodovia> Rodovias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}