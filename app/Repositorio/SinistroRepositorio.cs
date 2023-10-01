using app.Entidades;
using Repositorio.Interfaces;
using Entidades;

namespace Repositorio
{
    public class SinistroRepositorio : ISinistroRepositorio
    {
        private readonly AppDbContext db;

        public SinistroRepositorio(AppDbContext db)
        {
            this.db = db;
        }

        public Sinistro Criar(Sinistro sinistro)
        {
            db.Add(sinistro);
            return sinistro;
        }
    }
}
