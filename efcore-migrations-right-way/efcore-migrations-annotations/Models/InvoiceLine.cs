using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("InvoiceLine", Schema = "dbo")]
[Comment("The details for the invoices in the store.")]
[Index(nameof(InvoiceId), Name = "IFK_Invoice_InvoiceLine")]
[Index(nameof(TrackId), Name = "IFK_Track_InvoiceLine")]
public class InvoiceLine
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int InvoiceId { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int TrackId { get; set; }
    [Column(TypeName = "numeric(10,2)")]
    [Required]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int Quantity { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("InvoiceLines")]
    [ForeignKey("InvoiceForeignKey")]
    public Invoice? Invoice { get; set; }
    [InverseProperty("InvoiceLines")]
    [ForeignKey("TrackForeignKey")]
    public Track? Track { get; set; }
}