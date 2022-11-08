using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Comment("The customers that have purchased tracks in the store.")]
[Index(nameof(SupportRepId), Name = "IFK_Employee_Customer")]
public class Customer
{
    [Column(TypeName = "int", Order = 0)]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(40)", Order = 1)]
    [MaxLength(40)]
    [Required]
    public string? FirstName { get; set; }
    [Column(TypeName = "nvarchar(40)", Order = 2)]
    [MaxLength(40)]
    [Required]
    public string? LastName { get; set; }
    [Column(TypeName = "nvarchar(80)", Order = 3)]
    [MaxLength(80)]
    [Required]
    public string? DisplayName { get; set; }
    [Column(TypeName = "nvarchar(80)", Order = 4)]
    [MaxLength(80)]
    public string? Company { get; set; }
    [Column(TypeName = "nvarchar(70)", Order = 5)]
    [MaxLength(70)]
    [Required]
    public string? Address { get; set; }
    [Column(TypeName = "nvarchar(40)", Order = 6)]
    [MaxLength(40)]
    [Required]
    public string? City { get; set; }
    [Column(TypeName = "nvarchar(40)", Order = 7)]
    [MaxLength(40)]
    [Required]
    public string? State { get; set; }
    [Column(TypeName = "nvarchar(40)", Order = 8)]
    [MaxLength(40)]
    public string? Country { get; set; }
    [Column("ZipCode", TypeName = "nvarchar(10)", Order = 9)]
    [MaxLength(10)]
    [Required]
    public string? PostalCode { get; set; }
    [Column(TypeName = "nvarchar(24)", Order = 10)]
    [MaxLength(24)]
    public string? Phone { get; set; }
    [Column(TypeName = "nvarchar(24)", Order = 11)]
    [MaxLength(24)]
    public string? Fax { get; set; }
    [Column(TypeName = "nvarchar(60)", Order = 12)]
    [MaxLength(60)]
    [Required]
    public string? Email { get; set; }
    [Column(TypeName = "int", Order = 13)]
    public int SupportRepId { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime", Order = 14)]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime", Order = 15)]
    public DateTime? Updated { get; set; }
    
    [ForeignKey("SupportRepForeignKey")]
    public Employee? SupportRep { get; set; }

    [InverseProperty("InvoiceLines")]
    public ICollection<Invoice>? Invoices { get; set; }
}