using service.Interfaces;
using repositorio.Interfaces;


namespace
{
    public class SinistroService
    {
        private readonly ISinistroRepositorio sinistroRepositorio;
        public SinistroService(ISinistroRepositorio sinistroRepositorio)
        {
            this.sinistroRepositorio = sinistroRepositorio;
        }
    }
}