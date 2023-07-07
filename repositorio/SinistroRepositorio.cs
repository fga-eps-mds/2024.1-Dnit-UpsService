using dominio.Enums;
using repositorio.Interfaces;
using repositorio.Contexto;
using static repositorio.Contexto.ResolverContexto;

namespace repositorio
{
    public class SinistroRepositorio : ISinistroRepositorio
    {
        private readonly IContexto contexto;

        public SinistroRepositorio(ResolverContextoDelegate resolverContexto)
        {
            contexto = resolverContexto(ContextoBancoDeDados.Postgresql);
        }
    }
}