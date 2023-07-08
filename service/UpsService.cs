using dominio;
using repositorio.Interfaces;
using service.Interfaces;
using System;
using System.Collections.Generic;

namespace service
{
    public class UpsService : IUpsService
    {
        private readonly IUpsRepositorio upsRepositorio;
        private const double EarthRadiusKm = 6371.0;


        public UpsService(IUpsRepositorio upsRepositorio)
        {
            this.upsRepositorio = upsRepositorio;
        }

        public IEnumerable<Sinistro> ObterSinistros()
        {
            IEnumerable<Sinistro> sinistros = upsRepositorio.ObterSinistros();

            return sinistros;
        }

        public Sinistro CalcularUpsSinistro(Sinistro sinistro)
        {
            if (sinistro.Mortos > 0)
            {
                sinistro.Ups = 13;
                return sinistro;
            }
            else if (sinistro.Tipo == "Atropelamento" && sinistro.Feridos > 0)
            {
                sinistro.Ups = 6;
                return sinistro;
            }
            else if ( sinistro.Feridos > 0)
            {
                sinistro.Ups = 4;
                return sinistro;
            } else
            {
                sinistro.Ups = 1;
                return sinistro;
            }
        }

        public void CalcularUpsEmMassa()
        {
            IEnumerable<Sinistro> sinistros = upsRepositorio.ObterSinistros();

            foreach(Sinistro sinistro in sinistros)
            {
                Sinistro sinistroComUpsCalculado = CalcularUpsSinistro(sinistro);

                upsRepositorio.AtualizarUpsSinistro(sinistroComUpsCalculado);
            }
        }

        public UpsDetalhado CalcularUpsEscola(Escola escola)
        {
            IEnumerable<Sinistro> sinistros = ObterSinistros();
            UpsDetalhado upsDetalhado = new();
            
            double raio = 2.0; //raio esta em quilometro

            Dictionary<int, int> upsPorAno = new()
            {
                { 2022, 0 },
                { 2021, 0 },
                { 2020, 0 },
                { 2019, 0 },
                { 2018, 0 }
            };

            foreach (Sinistro sinistro in sinistros)
            {

                if (CalculateDistance(sinistro.Latitude, sinistro.Longitude, escola.Latitude, escola.Longitude) <= raio)
                {
                    upsPorAno[sinistro.Data.Year] += sinistro.Ups ?? 0;
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



        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static decimal ConvertToRadians(decimal grau)
        {
            return grau * (decimal)Math.PI / 180;
        }

        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = EarthRadiusKm * c;
            return distance;
        }
    }
}
