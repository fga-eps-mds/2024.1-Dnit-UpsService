using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Stub
{
    public class SinistroStub
    {
        public Sinistro Ups1()
        public SinistroDTO ObterSinistroDTO()
        {
            return new Sinistro
            return new SinistroDTO
            {
                Id = 146359,
                Gravidade = "Sem v�tima",
                Tipo = "Colis�o lateral",
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
                Tipo = "Colis�o transversal",
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
                IdSinistro = 5000000
                SiglaUF = "DF"
                Rodovia = 123
                Km = 123
                Snv = 316BPI0550
                Sentido = "Decrescente"
                Solo = "Urbano"
                Data = 01/01/2050 01:35:00
                Tipo = "Tombamento"
                Causa = "Ingest�o de �lcool"
                Gravidade = "Com morto"
                Feridos = 100
                Mortos = 100
                Ups = 13
                Latitude = "-21,228445"
                Longitude = "-44,1347544"
            };
        }
    }
}
