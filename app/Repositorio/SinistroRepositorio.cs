using Entidades.Enums;
using Repositorio.Interfaces;
using Repositorio.Contexto;
using static Repositorio.Contexto.ResolverContexto;
using Dapper;
using Entidades;
using app.Entidades;

namespace Repositorio
{
    public class SinistroRepositorio : ISinistroRepositorio
    {
        private readonly IContexto contexto;
        private readonly AppDbContext db;

        public SinistroRepositorio(ResolverContextoDelegate resolverContexto, AppDbContext db)
        {
            contexto = resolverContexto(ContextoBancoDeDados.Postgresql);
            this.db = db;
        }

        public Sinistro Criar(Sinistro sinistro)
        {
            var sqlInserirSinistro = @"INSERT INTO public.sinistro(id, uf, rodovia, quilometro, snv, sentido, solo, data, tipo, causa,
            gravidade, feridos, mortos, latitude, longitude, ups)
            VALUES(@Id, @SiglaUF, @Rodovia, @Km,@Snv, @Sentido, 
            @Solo, @Data, @Tipo, @Causa, @Gravidade, 
            @Feridos, @Mortos,   
            @Latitude, @Longitude, @Ups)";

            var sin = new Sinistro
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
            // contexto?.Conexao.Execute(sqlInserirSinistro, parametrosSinistro);

            db.Add(sinistro);
            return sin;
        }
    }
}


    