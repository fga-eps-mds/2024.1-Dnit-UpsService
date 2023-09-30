namespace Entidades
{
    public class RodoviaDTO
    {

        public int AnoApuracao { get; set; }
        public string SiglaUF { get; set; }
        public int NumeroRodovia { get; set; }
        public string TipoTrecho { get; set; }
        public string CodigoSNV { get; set; }
        public string LocalInicioFim { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public double Extensao { get; set; }
        public string Superficie { get; set; }
        public string? FederalCoincidente { get; set; }
        public string? EstadualCoincidente { get; set; }
        public string? SuperficieEstadual { get; set; }
        public bool MP082 { get; set; }
        public string ConcessaoConvenio { get; set; }

    }


}
