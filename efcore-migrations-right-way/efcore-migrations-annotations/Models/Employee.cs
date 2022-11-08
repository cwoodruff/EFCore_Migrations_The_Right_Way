using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations_annotations.Models;

[Table("Album", Schema = "dbo")]
[Index(nameof(ReportsTo), Name = "IFK_Employee_ReportsTo")]
public class Employee
{
    [Column(TypeName = "int")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? LastName { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? FirstName { get; set; }
    [Column(TypeName = "nvarchar(80)")]
    [MaxLength(80)]
    [Required]
    public string? DisplayName { get; set; }
    [Column(TypeName = "nvarchar(30)")]
    [MaxLength(30)]
    [Required]
    public string? Title { get; set; }
    [Column(TypeName = "int")]
    public int ReportsTo { get; set; }
    [Column(TypeName = "datetime")]
    [Required]
    public DateTime BirthDate { get; set; }
    [Column(TypeName = "datetime")]
    [Required]
    public DateTime HireDate { get; set; }
    [Column(TypeName = "nvarchar(70)")]
    [MaxLength(70)]
    [Required]
    public string? Address { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? City { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    [Required]
    public string? State { get; set; }
    [Column(TypeName = "nvarchar(40)")]
    [MaxLength(40)]
    public string? Country { get; set; }
    [Column("ZipCode", TypeName = "nvarchar(10)")]
    [MaxLength(10)]
    [Required]
    public string? PostalCode { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    [MaxLength(24)]
    [Required]
    public string? Phone { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    [MaxLength(24)]
    public string? Fax { get; set; }
    [Column(TypeName = "nvarchar(60)")]
    [MaxLength(60)]
    [Required]
    public string? Email { get; set; }

    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    [NotMapped]
    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }
    
    [ForeignKey("ReportsToForeignKey")]
    public Employee? ReportsToNavigation { get; set; }
    [InverseProperty("SupportRep")]
    public ICollection<Customer>? Customers { get; set; }
    public ICollection<Employee>? InverseReportsToNavigation { get; set; }
}