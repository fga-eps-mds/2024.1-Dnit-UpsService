namespace dominio
{
    public class Rodovia
    {

        public int AnoDeApuracao { get; set; }
        public string SiglaUF { get; set; }
        public int IdRodovia { get; set; }
        public string TipoDeTrecho { get; set; }
        public string CodigoSNV { get; set; }
        public string LocalDeInicioEDeFim { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public double Extensao { get; set; }
        public string Superficie { get; set; }
        public string? FederalCoincidente { get; set; }
        public string? EstadualCoincidente { get; set; }
        public string? SuperficieEstadual { get; set; }
        public bool MP082 { get; set; }
        public string ConcessaoOuConvenio { get; set; }

    }


}
