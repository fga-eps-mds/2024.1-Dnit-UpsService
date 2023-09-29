using Dapper;
using Dominio;
using Dominio.Enums;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using static Repositorio.Contexto.ResolverContexto;

namespace Repositorio
{
    public class RodoviaRepositorio : IRodoviaRepositorio
    {
        private readonly IContexto contexto;

        public RodoviaRepositorio(ResolverContextoDelegate resolverContexto)
        {
            contexto = resolverContexto(ContextoBancoDeDados.Postgresql);
        }

        public void CadastrarRodovia(RodoviaDTO rodoviaDTO)
        {
            var sqlInserirRodovia = @"INSERT INTO public.rodovia( ano_apuracao, sigla_uf, numero_rodovia, tipo_trecho, codigo_snv,
                                      local_inicio_fim, km_inicial, km_final, extensao, superficie, federal_coincidente, estadual_coincidente,
                                      superficie_estadual, mp082, concessao_convenio)
                                      VALUES( @AnoApuracao, @SiglaUF, @NumeroRodovia, @TipoTrecho, @CodigoSNV, @LocalInicioFim, @KmInicial, @KmFinal,
                                      @Extensao, @Superficie, @FederalCoincidente, @EstadualCoincidente, @SuperficieEstadual, @MP082, @ConcessaoConvenio)";
            var parametrosRodovia = new
            {
                AnoApuracao = rodoviaDTO.AnoApuracao,
                SiglaUF = rodoviaDTO.SiglaUF,
                NumeroRodovia = rodoviaDTO.NumeroRodovia,
                TipoTrecho = rodoviaDTO.TipoTrecho,
                CodigoSNV = rodoviaDTO.CodigoSNV,
                LocalInicioFim = rodoviaDTO.LocalInicioFim,
                KmInicial = rodoviaDTO.KmInicial,
                KmFinal = rodoviaDTO.KmFinal,
                Extensao = rodoviaDTO.Extensao,
                Superficie = rodoviaDTO.Superficie,
                FederalCoincidente = rodoviaDTO.FederalCoincidente,
                EstadualCoincidente = rodoviaDTO.EstadualCoincidente,
                SuperficieEstadual = rodoviaDTO.SuperficieEstadual,
                MP082 = rodoviaDTO.MP082,
                ConcessaoConvenio = rodoviaDTO.ConcessaoConvenio
            };

            contexto?.Conexao.Execute(sqlInserirRodovia, parametrosRodovia);
        }
    }
}
