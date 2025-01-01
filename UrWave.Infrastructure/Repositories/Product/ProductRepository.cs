namespace UrWave.Infrastructure.Repositories.Product;

using Microsoft.EntityFrameworkCore;

using UrWave.Domain.AggregateModels.ProductAggregate;

public class ProductRepository : IProductRepository
{
    private readonly UrWaveContext _context;

    public ProductRepository(UrWaveContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products.Where(x => x.IsActive).AsQueryable();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsProductNameUniqueAsync(string name)
    {
        return !await _context.Products.AnyAsync(p => p.Name.ToLower() == name.ToLower() && p.IsActive);
    }
}