namespace efcore_migrations_fluentapi.Models;

public class Invoice
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string? BillingAddress { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingState { get; set; }
    public string? BillingCountry { get; set; }
    public string? BillingPostalCode { get; set; }
    public decimal Total { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    
    public Customer? Customer { get; set; }
    public ICollection<InvoiceLine>? InvoiceLines { get; set; }
}