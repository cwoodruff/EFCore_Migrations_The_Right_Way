namespace efcore_migrations_fluentapi.Models;

public class Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName { get; set; }
    public string? Company { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public int SupportRepId { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Employee? SupportRep { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}