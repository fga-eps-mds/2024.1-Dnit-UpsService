using dominio;
using System.Collections.Generic;

namespace service.Interfaces
{
    public interface IUpsService
    {
        public IEnumerable<Sinistro> ObterSinistros();
        public Sinistro CalcularUpsSinistro(Sinistro sinistro);
        public void CalcularUpsEmMassa();
        public int CalcularUpsEscola(Escola escola);
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}
