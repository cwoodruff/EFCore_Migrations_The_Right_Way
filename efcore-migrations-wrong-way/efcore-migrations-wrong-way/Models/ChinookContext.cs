using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_wrong_way.Models;

public class ChinookContext : DbContext
{
    public ChinookContext(DbContextOptions<ChinookContext> options)
        : base(options)
    {
    }
        
    public ChinookContext()
    {
        
    }
    
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
    public virtual DbSet<MediaType> MediaTypes { get; set; }
    public virtual DbSet<Playlist> Playlists { get; set; }
    public virtual DbSet<Track> Tracks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}