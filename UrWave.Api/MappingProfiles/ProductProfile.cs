namespace Shcool.Api.MappingProfiles;

using AutoMapper;

using UrWave.Api.Request.Product;
using UrWave.Application.Command.Product.CreateProduct;
using UrWave.Application.Command.Product.UpdateProduct;
using UrWave.Application.Query.Product.SearchProduct;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<SearchProductRequest, SearchProductQuery>();
    }
}