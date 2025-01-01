namespace UrWave.Application.Command.Product.DeleteProduct;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse<bool>>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return response.BusinessValidationError(new List<string> { $"The product with Id {request.Id} does not exist." });
        }

        product.Delete();

        _productRepository.UpdateAsync(product);

        await _productRepository.SaveChangesAsync();

        return response.SuccessResponse(true);
    }
}