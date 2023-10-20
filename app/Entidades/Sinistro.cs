using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api;

namespace Entidades
{
    public class Sinistro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UF Uf { get; set; }

        [Required]
        public int Rodovia { get; set; }

        [Required]
        public double Km { get; set; }

        [MaxLength(20)]
        public string? Snv { get; set; }

        [MaxLength(200)]
        public string? Sentido { get; set; }

        [MaxLength(100)]
        public string? Solo { get; set; }

        [MaxLength(200)]
        public string? Tipo { get; set; }

        [MaxLength(200)]
        public string? Causa { get; set; }
        public string? Gravidade { get; set; }

        [Required]
        public int Feridos { get; set; }

        [Required]
        public int Mortos { get; set; }
        public int? Ups { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [NotMapped]
        public DateTimeOffset Data { get; set; }

        [Required]
        public DateTime DataUtc
        {
            get => Data.UtcDateTime;
            set => Data = new DateTimeOffset(value, TimeSpan.Zero);
        }

        public void CalcularUps()
        {
            if (Mortos > 0)
            {
                Ups = 13;
            }
            else if (Tipo == "Atropelamento" && Feridos > 0)
            {
                Ups = 6;
            }
            else if (Feridos > 0)
            {
                Ups = 4;
            }
            else
            {
                Ups = 1;
            }
        }
    }
}
