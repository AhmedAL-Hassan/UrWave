namespace UrWave.Domain.AggregateModels.ProductAggregate;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);

    IQueryable<Product> GetAll();

    Task AddAsync(Product product);

    void UpdateAsync(Product product);

    void DeleteAsync(Product product);

    Task SaveChangesAsync();

    Task<bool> IsProductNameUniqueAsync(string name);
}