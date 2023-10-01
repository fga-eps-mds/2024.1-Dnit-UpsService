using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Sinistro
    {
        public int Id { get; set; }
        public string? SiglaUF { get; set; }
        public int Rodovia { get; set; }
        public double Km { get; set; }
        public string? Snv { get; set; }
        public string? Sentido { get; set; }
        public string? Solo { get; set; }
        [NotMapped]
        public DateTimeOffset Data { get; set; }

        public DateTime DataUtc
        {
            get => Data.UtcDateTime;
            set => Data = new DateTimeOffset(value, TimeSpan.Zero);
        }
        
        public string? Tipo { get; set; }
        public string? Causa { get; set; }
        public string? Gravidade { get; set; }
        public int Feridos { get; set; }
        public int Mortos { get; set; }
        public int? Ups { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void CalcularUps()
        {
            if (Mortos > 0)
            {
                Ups = 13;
                return;
            }
            else if (Tipo == "Atropelamento" && Feridos > 0)
            {
                Ups = 6;
                return;
            }
            else if (Feridos > 0)
            {
                Ups = 4;
                return;
            }
            else
            {
                Ups = 1;
                return;
            }
        }
    }
}
