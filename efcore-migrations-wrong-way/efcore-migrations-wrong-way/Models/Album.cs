namespace efcore_migrations_wrong_way.Models;

public class Album
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }

    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}