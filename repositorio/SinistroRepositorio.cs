using dominio.Enums;
using repositorio.Interfaces;
using repositorio.Contexto;
using static repositorio.Contexto.ResolverContexto;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System;
using System.Linq;
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
            var sqlInserirSinistro = @"INSERT INTO public.sinistro(uf, rodovia, quilometro, sentido, solo, data, tipo, causa,
            gravidade, feridos, mortos, snv, id, latitude, longitude)
            VALUES(@Sigla_uf, @Rodovia, @Km, @Sentido, 
            @Solo, @Data, @Tipo, @Causa, @Gravidade, 
            @Feridos, @Mortos, @Snv, @Id_sinistro,   
            @Latitude, @Longitude)";

            var parametrosSinistro = new
            {
                Sigla_uf = sinistro.SiglaUF,
                Rodovia = sinistro.Rodovia,
                Km = sinistro.Km,
                Sentido = sinistro.Sentido,
                Solo = sinistro.Solo,
                Data = sinistro.Data,
                Tipo = sinistro.Tipo,
                Causa = sinistro.Causa,
                Gravidade = sinistro.Gravidade,
                Feridos = sinistro.Feridos,
                Mortos = sinistro.Mortos,
                Snv = sinistro.Snv,
                Id_sinistro = sinistro.IdSinistro,
                Latitude = sinistro.Latitude,
                Longitude = sinistro.Longitude,
                
            };

            contexto?.Conexao.Execute(sqlInserirSinistro, parametrosSinistro);
        }

    }
}


    