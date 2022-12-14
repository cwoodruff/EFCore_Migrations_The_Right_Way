namespace efcore_migrations_wrong_way.Models;

public class InvoiceLine
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public Invoice? Invoice { get; set; }
    public Track? Track { get; set; }
}