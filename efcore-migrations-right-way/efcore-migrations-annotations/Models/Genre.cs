namespace efcore_migrations_annotations.Data;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public ICollection<Track>? Tracks { get; set; }
}