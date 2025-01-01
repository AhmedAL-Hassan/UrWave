namespace UrWave.Application.Command.Product.CreateProduct;

using MediatR;

using UrWave.Domain.AggregateModels.ProductAggregate;

using UrWave.Domain.DataModels.Product;

public sealed class CreateProductCommand : IRequest<BaseResponse<Product>>, IProductModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}