using Moq;
using Repositorio.Interfaces;
using Service;
using Service.Interfaces;
using Xunit;

namespace test
{
    public class UpsServiceTest
    {
        [Fact]
        public void CalcularDistancia_QuandoLatLongForPassada_DeveCalcularDistancia()
        {
            double distancia = 1878.5472845077677;
            double lat1 = -19.83990774;
            double long1 = -43.87701717;
            double lat2 = -3.7437141;
            double long2 = -38.6158061;

            Mock <IUpsRepositorio> upsRepositorio = new();

            IUpsService upsService = new UpsService(upsRepositorio.Object);

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

            Mock<IUpsRepositorio> upsRepositorio = new();

            IUpsService upsService = new UpsService(upsRepositorio.Object);

            double distanciaCalculada = upsService.CalcularDistancia(lat1, long1, lat2, long2);

            Assert.Equal(distancia, distanciaCalculada);
        }
    }
}