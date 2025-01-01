namespace UrWave.Application.Command.Product.CreateProduct;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

using UrWave.Application;
using UrWave.Application.Command.Product.UpdateProduct;
using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<Product>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Product>();

        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return response.BusinessValidationError(new List<string> { $"The product with Id {request.Id} does not exist." });
        }

        var productNameUnique = await _productRepository.IsProductNameUniqueAsync(request.Name);

        if (!productNameUnique)
        {
            return response.BusinessValidationError(new List<string> { "Product name must be unique." });
        }

        product.Update(request);

        _productRepository.UpdateAsync(product);

        await _productRepository.SaveChangesAsync();

        return response.SuccessResponse(product);
    }
}