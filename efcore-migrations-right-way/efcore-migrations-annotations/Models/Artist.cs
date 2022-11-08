using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Comment("Artists in the store")]
[Index(nameof(Name), Name = "I_Artist_Name")]
public class Artist
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(120)")]
    [MaxLength(120)]
    [Required]
    [Comment("The name of the artist")]
    public string? Name { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("Artist")]
    public ICollection<Album>? Albums { get; set; }
}