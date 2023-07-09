using dominio.Enums;
using repositorio.Interfaces;
using repositorio.Contexto;
using static repositorio.Contexto.ResolverContexto;
using Dapper;
using dominio;

namespace repositorio
{
    public class SinistroRepositorio : ISinistroRepositorio
    {
        private readonly IContexto contexto;

        public SinistroRepositorio(ResolverContextoDelegate resolverContexto)
        {
            contexto = resolverContexto(ContextoBancoDeDados.Postgresql);
        }

        public void CadastrarSinistro(Sinistro sinistro)
        {
            var sqlInserirSinistro = @"INSERT INTO public.sinistro(id, uf, rodovia, quilometro, snv, sentido, solo, data, tipo, causa,
            gravidade, feridos, mortos, latitude, longitude, ups)
            VALUES(@Id, @SiglaUF, @Rodovia, @Km,@Snv, @Sentido, 
            @Solo, @Data, @Tipo, @Causa, @Gravidade, 
            @Feridos, @Mortos,   
            @Latitude, @Longitude, @Ups)";

            var parametrosSinistro = new
            {
                Id = sinistro.Id,
                SiglaUF = sinistro.SiglaUF,
                Rodovia = sinistro.Rodovia,
                Km = sinistro.Km,
                Snv = sinistro.Snv,
                Sentido = sinistro.Sentido,
                Solo = sinistro.Solo,
                Data = sinistro.Data,
                Tipo = sinistro.Tipo,
                Causa = sinistro.Causa,
                Gravidade = sinistro.Gravidade,
                Feridos = sinistro.Feridos,
                Mortos = sinistro.Mortos,
                Latitude = sinistro.Latitude,
                Longitude = sinistro.Longitude,
                Ups = sinistro.Ups,
                
            };

            contexto?.Conexao.Execute(sqlInserirSinistro, parametrosSinistro);
        }
    }
}


    