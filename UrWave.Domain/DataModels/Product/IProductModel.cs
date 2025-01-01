namespace UrWave.Domain.DataModels.Product;

public interface IProductModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}