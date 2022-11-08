using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Comment("The sets of tracks that have been curated for customers to buy.")]
[Index(nameof(Name), Name = "I_Playlist_Name")]
public class Playlist
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(120)")]
    [MaxLength(120)]
    [Required]
    public string? Name { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("Playlists")]
    public ICollection<Track>? Tracks { get; set; }
}