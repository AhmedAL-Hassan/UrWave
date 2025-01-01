namespace UrWave.Application.Query.Product.GetProductById;

using MediatR;

using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class GetProductByIdQuery : IRequest<BaseResponse<Product>>
{
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}