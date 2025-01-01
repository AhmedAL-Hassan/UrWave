namespace UrWave.Api.Request.Product;

using UrWave.Domain.DataModels.Product;

public class CreateProductRequest : IProductModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}