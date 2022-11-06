namespace efcore_migrations_wrong_way.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public ICollection<Track>? Tracks { get; set; }
}