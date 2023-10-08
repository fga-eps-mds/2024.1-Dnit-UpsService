using Entidades;

namespace Service.Interfaces
{
    public interface IUpsService
    {
        public Task CalcularUpsEmMassa();
        public Task<UpsDetalhado> CalcularUpsEscolaAsync(Escola escola);
        public double CalcularDistancia(double lat1, double long1, double lat2, double long2);
    }
}
