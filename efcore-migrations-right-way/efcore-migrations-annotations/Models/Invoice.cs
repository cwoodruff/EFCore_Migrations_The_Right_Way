using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Invoice", Schema = "dbo")]
[Comment("The customer's invoices.")]
[Index(nameof(CustomerId), Name = "IFK_Customer_Invoice")]
public class Invoice
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "int")]
    [Required]
    public int CustomerId { get; set; }
    [Column(TypeName = "datetime")]
    [Required]
    public DateTime InvoiceDate { get; set; }
    [Column(TypeName = "nvarchar(70)")]
    [MaxLength(70)]
    [Required]
    public string? BillingAddress { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? BillingCity { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? BillingState { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    public string? BillingCountry { get; set; }
    [Column("BillingZipCode", TypeName = "nvarchar(10)")]
    [MaxLength(10)]
    [Required]
    public string? BillingPostalCode { get; set; }
    [Column(TypeName = "numeric(10,2)")]
    [Required]
    public decimal Total { get; set; }
    
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [InverseProperty("Invoices")]
    [ForeignKey("CustomerForeignKey")]
    public Customer? Customer { get; set; }
    [InverseProperty("Invoice")]
    public ICollection<InvoiceLine>? InvoiceLines { get; set; }
}