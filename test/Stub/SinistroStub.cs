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
        public SinistroDTO ObterSinistroDTO()
        {
            return new SinistroDTO
            {
                IdSinistro = 5000000
                SiglaUF = "DF"
                Rodovia = 123
                Km = 123
                Snv = 316BPI0550
                Sentido = "Decrescente"
                Solo = "Urbano"
                Data = 01/01/2050 01:35:00
                Tipo = "Tombamento"
                Causa = "Ingestão de álcool"
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