using Dapper;
using dominio;
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

        public void AtualizarUpsSinistro(Sinistro sinistro)
        {
            var sql = @"UPDATE public.sinistro SET ups = @Ups WHERE id = @Id AND latitude = @Latitude AND longitude = @Longitude";

            var parametros = new
            {
                Ups = sinistro.Ups,
                Id = sinistro.Id,
                Latitude = sinistro.Latitude,
                Longitude = sinistro.Longitude
            };

            contexto?.Conexao.Execute(sql, parametros);
        }

        public IEnumerable<Sinistro> ObterSinistros()
        {
            var sql = @"SELECT id, tipo, gravidade, feridos, mortos, latitude, longitude, ups, data from public.sinistro";

            var sinistros = contexto?.Conexao.Query<Sinistro>(sql);

            return sinistros;
        }
    }
}
