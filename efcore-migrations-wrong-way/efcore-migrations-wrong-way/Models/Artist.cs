namespace efcore_migrations_wrong_way.Models;

public class Artist
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Album>? Albums { get; set; }
}