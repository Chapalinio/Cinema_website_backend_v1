namespace homework10WEB_API.Models.Entities;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int LengthInMinuts { get; set; }
}
