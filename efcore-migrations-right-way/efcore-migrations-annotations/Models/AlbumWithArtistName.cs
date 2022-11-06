namespace efcore_migrations_annotations.Models;

public abstract class AlbumWithArtistName
{
    public string? Title { get; set; }
    public int ArtistId { get; set; }
    public string? Name { get; set; }
}