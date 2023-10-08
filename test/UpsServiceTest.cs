using app.Entidades;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repositorio.Interfaces;
using Service;

namespace test
{
    public class UpsServiceTest
    {
        private readonly DbContextOptions<AppDbContext> options = new();
        private readonly Mock<AppDbContext> mockDb;
        private readonly Mock<ISinistroRepositorio> sinistroRepositorio;
        private readonly UpsService upsService;

        public UpsServiceTest()
        {
            mockDb = new(options);
            sinistroRepositorio = new();
            upsService = new UpsService(sinistroRepositorio.Object, mockDb.Object);
        }

        [Fact]
        public void CalcularDistancia_QuandoLatLongForPassada_DeveCalcularDistancia()
        {
            double distancia = 1878.5472845077677;
            double lat1 = -19.83990774;
            double long1 = -43.87701717;
            double lat2 = -3.7437141;
            double long2 = -38.6158061;

            double distanciaCalculada = upsService.CalcularDistancia(lat1, long1, lat2, long2);

            Assert.Equal(distancia, distanciaCalculada);
        }

        [Fact]
        public void CalcularDistancia_QuandoLatLongForPassadaIgual_DistanciaDeveSerZero()
        {
            double distancia = 0;
            double lat1 = -19.83990774;
            double long1 = -43.87701717;
            double lat2 = -19.83990774;
            double long2 = -43.87701717;

            double distanciaCalculada = upsService.CalcularDistancia(lat1, long1, lat2, long2);

            Assert.Equal(distancia, distanciaCalculada);
        }
    }
}