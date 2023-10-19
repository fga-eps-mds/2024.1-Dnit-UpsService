using System.ComponentModel.DataAnnotations;
using api;

namespace Entidades
{
    public class Rodovia
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public UF Uf { get; set; }

        [Required]
        public int AnoApuracao { get; set; }

        [Required]
        public int NumeroRodovia { get; set; }
        public string TipoTrecho { get; set; }
        public string CodigoSNV { get; set; }
        public string LocalInicioFim { get; set; }

        [Required]
        public double KmInicial { get; set; }

        [Required]
        public double KmFinal { get; set; }
        [Required]
        public double Extensao { get; set; }
        public string Superficie { get; set; }
        public string? FederalCoincidente { get; set; }
        public string? EstadualCoincidente { get; set; }
        public string? SuperficieEstadual { get; set; }

        [Required]
        public bool MP082 { get; set; }
        public string ConcessaoConvenio { get; set; }
    }
}
