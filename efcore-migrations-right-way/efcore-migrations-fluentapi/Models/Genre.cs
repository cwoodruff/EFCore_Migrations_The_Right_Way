namespace efcore_migrations_fluentapi.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    
    public ICollection<Track>? Tracks { get; set; }
}