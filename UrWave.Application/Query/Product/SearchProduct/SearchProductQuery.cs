namespace UrWave.Application.Query.Product.SearchProduct;

using MediatR;

using System.Collections.Generic;

using UrWave.Domain.AggregateModels.ProductAggregate;

public sealed class SearchProductQuery : BasePagination, IRequest<BaseResponse<List<Product>>>
{
}