﻿namespace efcore_migrations_fluentapi.Data;

public class Playlist
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public ICollection<Track>? Tracks { get; set; }
}