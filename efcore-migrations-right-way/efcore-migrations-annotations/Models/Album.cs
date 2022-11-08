using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album")]
[Comment("Albums in the store")]
[Index(nameof(ArtistId), Name = "IFK_Artist_Album")]
public class Album
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(160)")]
    [MaxLength(160)]
    [Required]
    [Comment("The name of the album")]
    public string? Title { get; set; }
    [Column(TypeName = "int")]
    public int ArtistId { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }

    [ForeignKey("ArtistForeignKey")]
    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}