using Entidades.Enums;

namespace Repositorio.Contexto
{
    public class ResolverContexto
    {
        public delegate IContexto? ResolverContextoDelegate(ContextoBancoDeDados contexto);
    }
}
