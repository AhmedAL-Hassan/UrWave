namespace UrWave.Application.Query.Product.GetProductById;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, BaseResponse<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Product>();

        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return response.BusinessValidationError(new List<string> { $"The product with Id {request.Id} does not exist." });
        }

        return response.SuccessResponse(product);
    }
}