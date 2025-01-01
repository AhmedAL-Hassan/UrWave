namespace UrWave.Application.Command.Product.CreateProduct;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

using UrWave.Application;
using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Product>();

        var productNameUnique = await _productRepository.IsProductNameUniqueAsync(request.Name);

        if (!productNameUnique)
        {
            return response.BusinessValidationError(new List<string> { "Product name must be unique." });
        }

        var product = Product.New(request);

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return response.SuccessResponse(product);
    }
}