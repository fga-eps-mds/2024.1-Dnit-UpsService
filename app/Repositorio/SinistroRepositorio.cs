using api;
using app.Entidades;
using Repositorio.Interfaces;
using Entidades;
using Microsoft.EntityFrameworkCore;
using api.Escolas;

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
                Id = sinistro.Id,
                Uf = sinistro.Uf,
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

        public async Task<ListaPaginada<Sinistro>> ListarPaginadaAsync(PesquisaSinistroFiltro filtro)
        {
            var total = await db.Sinistros.CountAsync();
            var sinistros = await db.Sinistros
                .OrderBy(s => s.Id)
                .Skip(filtro.ItemsPorPagina * (filtro.Pagina - 1))
                .Take(filtro.ItemsPorPagina)
                .ToListAsync();
            return new ListaPaginada<Sinistro>(sinistros, filtro.Pagina, filtro.ItemsPorPagina, total);
        }

        public async Task<IEnumerable<Sinistro>> ObterTodosAsync()
        {
            var sinistros = await db.Sinistros.ToListAsync();
            return sinistros;
        }

        public async Task<IEnumerable<Sinistro>> ObterAPartirDoAnoDentroDeRaioAsync(Escola escola, double raioKm, uint ano)
        {
            var sinistrosFiltradosPorAno = db.Sinistros
                .Where(s => s.Data.Year >= ano);

            var sinistrosDentroDoRaio = sinistrosFiltradosPorAno
                .Where(s => CalcularDistancia(
                    s.Latitude, s.Longitude, escola.Latitude, escola.Longitude) < raioKm);

            return await sinistrosDentroDoRaio.ToListAsync();
        }

        public double CalcularDistancia(double lat1, double long1, double lat2, double long2)
        {
            const double raioTerraEmKm = 6371.0;

            var diferencaLatitude = ConverterParaRadianos(lat2 - lat1);
            var diferencaLongitude = ConverterParaRadianos(long2 - long1);

            var primeiraParteFormula = Math.Sin(diferencaLatitude / 2) * Math.Sin(diferencaLatitude / 2) +
                    Math.Cos(ConverterParaRadianos(lat1)) * Math.Cos(ConverterParaRadianos(lat2)) *
                    Math.Sin(diferencaLongitude / 2) * Math.Sin(diferencaLongitude / 2);

            var resultadoFormula = 2 * Math.Atan2(Math.Sqrt(primeiraParteFormula), Math.Sqrt(1 - primeiraParteFormula));
            var distance = raioTerraEmKm * resultadoFormula;
            return distance;
        }

        public static double ConverterParaRadianos(double grau)
        {
            return grau * Math.PI / 180.0;
        }
    }
}
