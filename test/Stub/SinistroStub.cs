using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dominio;
using System;

namespace test.Stub
{
    public class SinistroStub
    {
        public Sinistro Ups1()
        {
            return new Sinistro
            {
                Id = 146359,
                Gravidade = "Sem vítima",
                Tipo = "Colisão lateral",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 0,
                Data = DateTime.Now
            };
        }

        public Sinistro Ups4()
        {
            return new Sinistro
            {
                Id = 146409,
                Gravidade = "Com ferido",
                Tipo = "Colisão transversal",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 1,
                Data = DateTime.Now
            };
        }

        public Sinistro Ups6()
        {
            return new Sinistro
            {
                Id = 146409,
                Gravidade = "Com ferido",
                Tipo = "Atropelamento",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 1,
                Data = DateTime.Now
            };
        }

        public Sinistro Ups13()
        {
            return new Sinistro
            {
                Id = 146409,
                Gravidade = "Com morto",
                Tipo = "Atropelamento",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 1,
                Feridos = 0,
                Data = DateTime.Now
            };
        }
        public Sinistro ObterSinistroDTO()
        {
            return new Sinistro
            {
                Id = 5000000,
                SiglaUF = "DF",
                Rodovia = 123,
                Km = 123,
                Snv = "316BPI0550",
                Sentido = "Decrescente",
                Solo = "Urbano",
                Data = DateTime.Now,
                Tipo = "Tombamento",
                Causa = "Ingestão de álcool",
                Gravidade = "Com morto",
                Feridos = 100,
                Mortos = 100,
                Ups = 13,
                Latitude = 2.228445,
                Longitude = 44.1347544
            };
        }
    }
}

