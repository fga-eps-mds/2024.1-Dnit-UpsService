using app.Entidades;
using Entidades;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class RodoviaRepositorio : IRodoviaRepositorio
    {
        private readonly AppDbContext db;

        public RodoviaRepositorio(AppDbContext db)
        {
            this.db = db;
        }

        public Rodovia CadastrarRodovia(RodoviaDTO rodovia)
        {
            // var sqlInserirRodovia = @"INSERT INTO public.rodovia( ano_apuracao, sigla_uf, numero_rodovia, tipo_trecho, codigo_snv,
            //                           local_inicio_fim, km_inicial, km_final, extensao, superficie, federal_coincidente, estadual_coincidente,
            //                           superficie_estadual, mp082, concessao_convenio)
            //                           VALUES( @AnoApuracao, @SiglaUF, @NumeroRodovia, @TipoTrecho, @CodigoSNV, @LocalInicioFim, @KmInicial, @KmFinal,
            //                           @Extensao, @Superficie, @FederalCoincidente, @EstadualCoincidente, @SuperficieEstadual, @MP082, @ConcessaoConvenio)";
            // contexto?.Conexao.Execute(sqlInserirRodovia, parametrosRodovia);
            var rod = new Rodovia
            {
                AnoApuracao = rodovia.AnoApuracao,
                Uf = rodovia.SiglaUF,
                NumeroRodovia = rodovia.NumeroRodovia,
                TipoTrecho = rodovia.TipoTrecho,
                CodigoSNV = rodovia.CodigoSNV,
                LocalInicioFim = rodovia.LocalInicioFim,
                KmInicial = rodovia.KmInicial,
                KmFinal = rodovia.KmFinal,
                Extensao = rodovia.Extensao,
                Superficie = rodovia.Superficie,
                FederalCoincidente = rodovia.FederalCoincidente,
                EstadualCoincidente = rodovia.EstadualCoincidente,
                SuperficieEstadual = rodovia.SuperficieEstadual,
                MP082 = rodovia.MP082,
                ConcessaoConvenio = rodovia.ConcessaoConvenio,

            };

            db.Rodovias.Add(rod);
            return rod;
        }
    }
}
