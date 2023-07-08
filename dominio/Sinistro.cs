namespace dominio
{
    public class Sinistro
    {
        public int Id { get; set; }
        public string? Gravidade { get; set; }
        public int? Ups { get; set; }
        public string? Tipo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Mortos { get; set; }
        public int Feridos { get; set; }
        public DateTime Data { get; set; }
    }
}
