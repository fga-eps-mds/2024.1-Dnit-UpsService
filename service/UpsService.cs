using repositorio.Interfaces;
using service.Interfaces;

namespace service
{
    public class UpsService : IUpsService
    {
        private readonly IUpsRepositorio upsRepositorio;

        public UpsService(IUpsRepositorio upsRepositorio)
        {
            this.upsRepositorio = upsRepositorio;
        }
    }
}
