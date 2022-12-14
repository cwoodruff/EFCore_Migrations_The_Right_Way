namespace efcore_migrations_fluentapi.Models;

public class InvoiceLine
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    
    public Invoice? Invoice { get; set; }
    public Track? Track { get; set; }
}