namespace UrWave.Application.Query.Product.SearchProduct;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, BaseResponse<List<Product>>>
{
    private readonly IProductRepository _productRepository;

    public SearchProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<List<Product>>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<Product>>();

        try
        {
            var query = _productRepository.GetAll();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(product => product.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                var sortProperty = typeof(Product).GetProperty(request.SortColumn);

                if (sortProperty != null)
                {
                    if (request.SortDirection.ToLower() == "asc")
                    {
                        query = query.OrderBy(product => EF.Property<object>(product, request.SortColumn));
                    }
                    else
                    {
                        query = query.OrderByDescending(product => EF.Property<object>(product, request.SortColumn));
                    }
                }
            }

            var products = await query.Skip(request.Skip).Take(request.Take).ToListAsync();

            return response.SuccessResponse(products);
        }
        catch (Exception)
        {
            return response.BusinessValidationError(new List<string> { "Plesae put valid { SearchTerm }." });
        }
    }
}