namespace efcore_migrations_fluentapi.Models;

public class Album
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}