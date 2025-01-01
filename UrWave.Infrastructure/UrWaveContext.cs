namespace UrWave.Infrastructure;

using Microsoft.EntityFrameworkCore;

using UrWave.Domain.AggregateModels.ProductAggregate;
using UrWave.Domain.EntityConfiguration.Product;

public class UrWaveContext : DbContext
{
    public UrWaveContext(DbContextOptions<UrWaveContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}