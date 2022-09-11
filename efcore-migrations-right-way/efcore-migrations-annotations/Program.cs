
using efcore_migrations_annotations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace efcore_migrations_annotations;

class Program
{
    public static void Main(string[] args)
    {

    }
}

public class ChinookContextFactory : IDesignTimeDbContextFactory<ChinookContext>
{
    public ChinookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=chinook-annotations;Trusted_Connection=True;TrustServerCertificate=True;");

        return new ChinookContext(optionsBuilder.Options);
    }
}