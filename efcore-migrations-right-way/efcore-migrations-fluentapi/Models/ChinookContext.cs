using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_fluentapi.Models;

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
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=chinook-fluentapi;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(
            e =>
            {
                e.ToTable("Album", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Title).HasColumnType("nvarchar(160)");
                e.Property(e => e.ArtistId).HasColumnType("int");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                

                e.HasIndex(e => e.ArtistId, "IFK_Artist_Album");
                e.HasIndex(e => e.Id, "IPK_ProductItem");
                e.Property(e => e.Title).HasMaxLength(160);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_ArtistId");
            });
        
        modelBuilder.Entity<Artist>(
            e =>
            {
                e.ToTable("Artist", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Name).HasColumnType("nvarchar(120)").HasMaxLength(120);
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");

                e.HasIndex(e => e.Id, "IPK_Artist");
                e.HasIndex(e => e.Name, "I_Artist_Name");
            });
        
        modelBuilder.Entity<Customer>(
            e =>
            {
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.PostalCode).HasColumnType("nvarchar(10)").HasColumnName("ZipCode").HasMaxLength(10);
                e.Property(e => e.Address).HasColumnType("nvarchar(70)").HasMaxLength(70);
                e.Property(e => e.City).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.Company).HasColumnType("nvarchar(80)").HasMaxLength(80);
                e.Property(e => e.Country).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.Email).HasColumnType("nvarchar(60)").HasMaxLength(60);
                e.Property(e => e.Fax).HasColumnType("nvarchar(24)").HasMaxLength(24);
                e.Property(e => e.FirstName).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.LastName).HasColumnType("nvarchar(40)").HasMaxLength(20);
                e.Property(e => e.State).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.ToTable("Customer", schema: "dbo");
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");

                e.Property(e => e.DisplayName)
                    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.SupportRepId, "IFK_Employee_Customer");
                e.HasIndex(e => e.Id, "IPK_Customer");
                e.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SupportRepId);
            });
        
        modelBuilder.Entity<Employee>(
            e =>
            {
                e.ToTable("Employee", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Address).HasColumnType("nvarchar(70)").HasMaxLength(70);
                e.Property(e => e.BirthDate).HasColumnType("datetime");
                e.Property(e => e.City).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.Country).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.Email).HasColumnType("nvarchar(60)").HasMaxLength(60);
                e.Property(e => e.Fax).HasColumnType("nvarchar(24)").HasMaxLength(24);
                e.Property(e => e.FirstName).HasColumnType("nvarchar(40)").HasMaxLength(20);
                e.Property(e => e.HireDate).HasColumnType("datetime");
                e.Property(e => e.LastName).HasColumnType("nvarchar(40)").HasMaxLength(20);
                e.Property(e => e.Phone).HasColumnType("nvarchar(24)").HasMaxLength(24);
                e.Property(e => e.PostalCode).HasColumnType("nvarchar(10)").HasMaxLength(10);
                e.Property(e => e.State).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.Title).HasColumnType("nvarchar(30)").HasMaxLength(30);
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(e => e.DisplayName)
                    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.ReportsTo, "IFK_Employee_ReportsTo");
                e.HasIndex(e => e.Id, "IPK_Employee");
                
                e.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employee_Report")
                    .OnDelete(DeleteBehavior.NoAction);
                
            });
        
        modelBuilder.Entity<Genre>(
            e =>
            {
                e.ToTable("Genre", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Name).HasColumnType("nvarchar(120)");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.Id, "IPK_Genre");
                e.Property(e => e.Name).HasMaxLength(120);
            });
        
        modelBuilder.Entity<Invoice>(
            e =>
            {
                e.ToTable("Invoice", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.BillingAddress).HasColumnType("nvarchar(70)").HasMaxLength(70);
                e.Property(e => e.BillingCity).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.BillingCountry).HasColumnType("nvarchar(40)").HasMaxLength(40);
                e.Property(e => e.BillingPostalCode).HasColumnType("nvarchar(10)").HasMaxLength(10);
                e.Property(e => e.BillingState).HasColumnType("nvarchar(70)").HasMaxLength(40);
                e.Property(e => e.InvoiceDate).HasColumnType("datetime");
                e.Property(e => e.Total).HasColumnType("numeric(10, 2)");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.CustomerId, "IFK_Customer_Invoice");
                e.HasIndex(e => e.Id, "IPK_Invoice");
                
                e.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Customer");
            });
        
        modelBuilder.Entity<InvoiceLine>(
            e =>
            {
                e.ToTable("InvoiceLine", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");
                e.Property(e => e.Quantity).HasColumnType("int");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.InvoiceId, "IFK_Invoice_InvoiceLine");
                e.HasIndex(e => e.TrackId, "IFK_Track_InvoiceLine");
                e.HasIndex(e => e.Id, "IPK_InvoiceLine");
                
                e.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLines_Invoice");
                e.HasOne(d => d.Track)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLines_Track");
            });
        
        modelBuilder.Entity<MediaType>(
            e =>
            {
                e.ToTable("MediaType", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Name).HasColumnType("nvarchar(120)");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.Id, "IPK_MediaType");
                e.Property(e => e.Name).HasMaxLength(120);
            });
        
        modelBuilder.Entity<Playlist>(
            e =>
            {
                e.ToTable("Playlist", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Name).HasColumnType("nvarchar(120)");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.Id, "IPK_Playlist");
                e.HasIndex(e => e.Name, "I_Playlist_Name");
                e.Property(e => e.Name).HasMaxLength(120);
                e.HasMany(d => d.Tracks)
                    .WithMany(p => p.Playlists)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlaylistTrack",
                        l => l.HasOne<Track>().WithMany().HasForeignKey("TrackId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistTrack_Track"),
                        r => r.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistTrack_Playlist"),
                        j =>
                        {
                            j.HasKey("PlaylistId", "TrackId").HasName("PK_Playlist_A4A6282E25869641");

                            j.ToTable("PlaylistTrack");

                            j.HasIndex(new[] { "PlaylistId" }, "IFK_Playlist_PlaylistTrack");

                            j.HasIndex(new[] { "TrackId" }, "IFK_Track_PlaylistTrack");

                            j.HasIndex(new[] { "PlaylistId" }, "IPK_PlaylistTrack");
                        });
            });
        
        modelBuilder.Entity<Track>(
            e =>
            {
                e.ToTable("Track", schema: "dbo");
                
                e.Property(e => e.Id).HasColumnType("int").ValueGeneratedOnAdd();
                e.Property(e => e.Name).HasColumnType("nvarchar(200)");
                e.Property(e => e.Composer).HasMaxLength(220);
                e.Property(e => e.Name).HasMaxLength(200);
                e.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");
                e.Property(e => e.Milliseconds).HasColumnType("int");
                e.Property(e => e.Bytes).HasColumnType("int");
                
                e.Ignore(e => e.Created);
                e.Ignore(e => e.Updated);
                
                e.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
                
                e.HasIndex(e => e.AlbumId, "IFK_Album_Track");
                e.HasIndex(e => e.GenreId, "IFK_Genre_Track");
                e.HasIndex(e => e.MediaTypeId, "IFK_MediaType_Track");
                e.HasIndex(e => e.Id, "IPK_Track");
                
                e.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_Track_AlbumId");
                e.HasOne(d => d.Genre)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Track_GenreId");
                e.HasOne(d => d.MediaType)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_MediaType");
            });
    }
}