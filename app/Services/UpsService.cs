using app.Entidades;
using Entidades;
using Repositorio.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class UpsService : IUpsService
    {
        private readonly ISinistroRepositorio sinistroRepositorio;
        private readonly AppDbContext db;
        private const double raioTerraEmKm = 6371.0;

        public UpsService(ISinistroRepositorio sinistroRepositorio, AppDbContext db)
        {
            this.sinistroRepositorio = sinistroRepositorio;
            this.db = db;
        }

        public async Task CalcularUpsEmMassaAsync()
        {
            var sinistros = await sinistroRepositorio.ObterTodosAsync();
            foreach (var sinistro in sinistros)
            {
                sinistro.CalcularUps();
            }
            await db.SaveChangesAsync();
        }

        public async Task<UpsDetalhado> CalcularUpsEscolaAsync(Escola escola)
        {
            var sinistros = await sinistroRepositorio.ObterTodosAsync();
            var upsDetalhado = new UpsDetalhado();

            double raio = 2.0; //raio esta em quilometro

            Dictionary<int, int> upsPorAno = new()
            {
                { 2022, 0 },
                { 2021, 0 },
                { 2020, 0 },
                { 2019, 0 },
                { 2018, 0 }
            };

            foreach (var sinistro in sinistros)
            {
                if (CalcularDistancia(sinistro.Latitude, sinistro.Longitude, escola.Latitude, escola.Longitude) <= raio)
                {
                    if (upsPorAno.ContainsKey(sinistro.Data.Year)) {
                        upsPorAno[sinistro.Data.Year] += sinistro.Ups ?? 0;
                    }
                }
            }

            upsDetalhado.Ups2022 = upsPorAno[2022];
            upsDetalhado.Ups2021 = upsPorAno[2021];
            upsDetalhado.Ups2020 = upsPorAno[2020];
            upsDetalhado.Ups2019 = upsPorAno[2019];
            upsDetalhado.Ups2018 = upsPorAno[2018];

            upsDetalhado.CalcularUpsGeral();
            return upsDetalhado;
        }

        public static double ConverterParaRadianos(double grau)
        {
            return grau * Math.PI / 180.0;
        }

        public double CalcularDistancia(double lat1, double long1, double lat2, double long2)
        {
            var diferencaLatitude = ConverterParaRadianos(lat2 - lat1);
            var diferencaLongitude = ConverterParaRadianos(long2 - long1);

            var primeiraParteFormula = Math.Sin(diferencaLatitude / 2) * Math.Sin(diferencaLatitude / 2) +
                    Math.Cos(ConverterParaRadianos(lat1)) * Math.Cos(ConverterParaRadianos(lat2)) *
                    Math.Sin(diferencaLongitude / 2) * Math.Sin(diferencaLongitude / 2);

            var resultadoFormula = 2 * Math.Atan2(Math.Sqrt(primeiraParteFormula), Math.Sqrt(1 - primeiraParteFormula));

            var distance = raioTerraEmKm * resultadoFormula;

            return distance;
        }
    }
}
