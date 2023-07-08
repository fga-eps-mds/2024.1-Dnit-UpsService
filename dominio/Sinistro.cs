namespace dominio
{
    public class Sinistro
    {
        public int IdSinistro { get; set; }
        public string? SiglaUF { get; set; }
        public int Rodovia { get; set; }
        public double Km { get; set; }
        public int Snv { get; set; }
        public string? Sentido { get; set; }
        public string? Solo { get; set; }
        public string? Data { get; set; }
        public string? Tipo { get; set; }
        public string? Causa { get; set; }
        public string? Gravidade { get; set; }
        public int Feridos { get; set; }
        public int Mortos { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
