using api;
using app.Entidades;
using Repositorio.Interfaces;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class SinistroRepositorio : ISinistroRepositorio
    {
        private readonly AppDbContext db;

        public SinistroRepositorio(AppDbContext db)
        {
            this.db = db;
        }

        public Sinistro Criar(SinistroDTO sinistro)
        {
            var sin = new Sinistro
            {
                SiglaUF = sinistro.SiglaUF,
                Rodovia = sinistro.Rodovia,
                Km = sinistro.Km,
                Snv = sinistro.Snv,
                Sentido = sinistro.Sentido,
                Solo = sinistro.Solo,
                Data = sinistro.Data,
                Tipo = sinistro.Tipo,
                Causa = sinistro.Causa,
                Gravidade = sinistro.Gravidade,
                Feridos = sinistro.Feridos,
                Mortos = sinistro.Mortos,
                Latitude = sinistro.Latitude,
                Longitude = sinistro.Longitude,
            };
            sin.CalcularUps();
            db.Sinistros.Add(sin);
            return sin;
        }

        public async Task<IEnumerable<Sinistro>> ObterTodosAsync()
        {
            return await db.Sinistros.ToListAsync();
        }
    }
}
