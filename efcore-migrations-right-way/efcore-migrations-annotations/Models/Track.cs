using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Comment("The tracks that are in the store to buy.")]
[Index(nameof(AlbumId), Name = "IFK_Album_Track")]
[Index(nameof(GenreId), Name = "IFK_Genre_Track")]
[Index(nameof(MediaTypeId), Name = "IFK_MediaType_Track")]
public class Track
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    [MaxLength(200)]
    [Required]
    public string? Name { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int AlbumId { get; set; }
    [Column(TypeName = "int")]
    public int MediaTypeId { get; set; }
    [Column(TypeName = "int")]
    public int GenreId { get; set; }
    [Column(TypeName = "nvarchar(220)")]
    [MaxLength(220)]
    public string? Composer { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int Milliseconds { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int Bytes { get; set; }
    [Column(TypeName = "numeric(10,2")]
    [Required]
    public decimal UnitPrice { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("Tracks")]
    [ForeignKey("AlbumForeignKey")]
    public virtual Album? Album { get; set; }
    [InverseProperty("Tracks")]
    [ForeignKey("GenreForeignKey")]
    public virtual Genre? Genre { get; set; }
    [InverseProperty("Tracks")]
    [ForeignKey("MediaTypeForeignKey")]
    public virtual MediaType? MediaType { get; set; }
    [InverseProperty("Track")]
    public virtual ICollection<InvoiceLine>? InvoiceLines { get; set; }
    [InverseProperty("Track")]
    public virtual ICollection<Playlist>? Playlists { get; set; }
}