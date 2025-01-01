namespace UrWave.Domain.AggregateModels.ProductAggregate;

using UrWave.Domain.DataModels.Product;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public double Price { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public string CreatedBy { get; private set; }

    public DateTime ModifyAt { get; private set; }

    public string ModifyBy { get; private set; }

    public static Product New(IProductModel model)
    {
        var instance = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "User",
            ModifyAt = DateTime.UtcNow,
            ModifyBy = "User"
        };

        return instance;
    }

    public void Update(IProductModel model)
    {
        Name = model.Name;
        Description = model.Description;
        Price = model.Price;
        ModifyAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsActive = false;
        ModifyAt = DateTime.UtcNow;
    }
}