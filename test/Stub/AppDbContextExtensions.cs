using app.Entidades;
using Entidades;
using test.Stub;

namespace Stub
{
    public static class AppDbContextExtensions
    {
        public static List<Sinistro> PopulaSinistros(this AppDbContext db, int limite = 1)
        {
            db.Clear();
            var sinistros = new List<Sinistro>();
            foreach(var sinistro in SinistroStub.ListarSinistros().Take(limite)) {
                db.Add(sinistro);
                sinistros.Add(sinistro);
            }
            db.SaveChanges();
            return sinistros;
        }

        public static void Clear(this AppDbContext db)
        {
            db.RemoveRange(db.Sinistros);
            db.SaveChanges();
        }
    }
}