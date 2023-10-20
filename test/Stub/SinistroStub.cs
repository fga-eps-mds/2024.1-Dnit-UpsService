using api;
using Entidades;
using Stub;

namespace test.Stub
{
    public class SinistroStub
    {
        public static Sinistro Ups1()
        {
            return new Sinistro
            {
                Id = Random.Shared.Next(),
                Gravidade = "Sem v�tima",
                Tipo = "Colis�o lateral",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 0,
                Data = new DateTime(2018, 1, 1)
            };
        }

        public static Sinistro Ups4()
        {
            return new Sinistro
            {
                Id = Random.Shared.Next(),
                Gravidade = "Com ferido",
                Tipo = "Colis�o transversal",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 1,
                Data = new DateTime(2019, 1, 1)
            };
        }

        public static Sinistro Ups6()
        {
            return new Sinistro
            {
                Id = Random.Shared.Next(),
                Gravidade = "Com ferido",
                Tipo = "Atropelamento",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 0,
                Feridos = 1,
                Data = new DateTime(2020, 1, 1)
            };
        }

        public static Sinistro Ups13()
        {
            return new Sinistro
            {
                Id = Random.Shared.Next(),
                Gravidade = "Com morto",
                Tipo = "Atropelamento",
                Latitude = -20.36999506,
                Longitude = -40.44402927,
                Mortos = 1,
                Feridos = 0,
                Data = new DateTime(2021, 1, 1)
            };
        }
        public static Sinistro ObterSinistroDTO()
        {
            return new Sinistro
            {
                Id = Random.Shared.Next(),
                Uf = UF.DF,
                Rodovia = 123,
                Km = 123,
                Snv = "316BPI0550",
                Sentido = "Decrescente",
                Solo = "Urbano",
                Data = DateTime.Now,
                Tipo = "Tombamento",
                Causa = "Ingest�o de �lcool",
                Gravidade = "Com morto",
                Feridos = 100,
                Mortos = 100,
                Ups = 13,
                Latitude = 2.228445,
                Longitude = 44.1347544
            };
        }

        public static IEnumerable<Sinistro> ListarSinistros()
        {
            while (true)
            {
                var sinistro = new Sinistro
                {
                    Id = Random.Shared.Next(),
                    Uf = Enum.GetValues<UF>().TakeRandom().FirstOrDefault(),
                    Ups = Random.Shared.Next() % 16,
                    Rodovia = 1,
                    Km = 1,
                    Feridos = Random.Shared.Next() % 30,
                    Mortos = Random.Shared.Next() % 10,
                    Latitude = Random.Shared.NextDouble() * 180 - 90,   // [-90, +90]
                    Longitude = Random.Shared.NextDouble() * 360 - 180, // [-180, +180]
                    Data = DateTimeOffset.Now,
                    Causa = $"Causa número {Random.Shared.Next()}",
                    Snv = $"Snv {Random.Shared.Next()}",
                    Sentido = $"Sentido {Random.Shared.Next()}",
                    Solo = $"Solo {Random.Shared.Next()}",
                    Tipo = $"Tipo {Random.Shared.Next()}",
                    Gravidade = $"Gravidade {Random.Shared.Next()}",
                };

                yield return sinistro;
            }
        }
    }
}

