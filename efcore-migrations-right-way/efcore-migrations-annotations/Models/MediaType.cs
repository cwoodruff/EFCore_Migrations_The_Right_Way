using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Comment("The types of media that customers can purchase music on the store.")]
public class MediaType
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(120)")]
    [Required]
    [MaxLength(120)]
    public string? Name { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("MediaType")]
    public ICollection<Track>? Tracks { get; set; }
}