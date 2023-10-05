namespace api;

public class SinistroDTO
{
    public int Id { get; set; }
    public string? SiglaUF { get; set; }
    public int Rodovia { get; set; }
    public double Km { get; set; }
    public string? Snv { get; set; }
    public string? Sentido { get; set; }
    public string? Solo { get; set; }
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
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
