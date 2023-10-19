using api;
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
            var rod = new Rodovia
            {
                Id = Guid.NewGuid(),
                Uf = rodovia.Uf,
                AnoApuracao = rodovia.AnoApuracao,
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
