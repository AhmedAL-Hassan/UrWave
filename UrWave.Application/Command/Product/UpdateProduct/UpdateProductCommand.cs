namespace UrWave.Application.Command.Product.UpdateProduct;

using MediatR;

using UrWave.Domain.AggregateModels.ProductAggregate;
using UrWave.Domain.DataModels.Product;

public sealed class UpdateProductCommand : IRequest<BaseResponse<Product>>, IProductModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}