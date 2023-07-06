using dominio.Enums;
using repositorio.Contexto;
using repositorio.Interfaces;
using static repositorio.Contexto.ResolverContexto;

namespace repositorio
{
    public class UpsRepositorio : IUpsRepositorio
    {
        private readonly IContexto contexto;
        public UpsRepositorio(ResolverContextoDelegate resolverContexto)
        {
            contexto = resolverContexto(ContextoBancoDeDados.Postgresql);
        }

    }
}
