namespace UrWave.Api.Request.Product;

using UrWave.Domain.DataModels.Product;

public class UpdateProductRequest : IProductModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}