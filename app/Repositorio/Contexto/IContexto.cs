using System.Data;

namespace Repositorio.Contexto
{
    public interface IContexto
    {
        IDbConnection Conexao { get; }
    }
}
