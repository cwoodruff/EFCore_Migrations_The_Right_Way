using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

//[View("Album", Schema = "dbo")] -- Not able in Annotations
[Comment("A view that has the artist name with the album data.")]
public abstract class AlbumWithArtistName
{
    [Column(TypeName = "nvarchar(160)")]
    [MaxLength(160)]
    public string? Title { get; set; }
    [Column(TypeName = "int")]
    public int ArtistId { get; set; }
    [Column(TypeName = "nvarchar(120)")]
    [MaxLength(120)]
    public string? Name { get; set; }
}