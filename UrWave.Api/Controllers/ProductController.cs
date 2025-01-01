namespace UrWave.Api.Controllers;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using UrWave.Api.Request.Product;
using UrWave.Application.Command.Product.CreateProduct;
using UrWave.Application.Command.Product.DeleteProduct;
using UrWave.Application.Command.Product.UpdateProduct;
using UrWave.Application.Query.Product.GetProductById;
using UrWave.Application.Query.Product.SearchProduct;

public class ProductController : BaseController
{
    public ProductController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
        var getSchoolByIdQuery = new GetProductByIdQuery(id);

        var response = await Mediator.Send(getSchoolByIdQuery);

        return await response.GetActionResultAsync();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var createProductCommand = Mapper.Map<CreateProductCommand>(request);

        var response = await Mediator.Send(createProductCommand);

        return await response.GetActionResultAsync();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProductAsync(UpdateProductRequest request)
    {
        var updateProductCommand = Mapper.Map<UpdateProductCommand>(request);

        var response = await Mediator.Send(updateProductCommand);

        return await response.GetActionResultAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(Guid id)
    {
        var deleteProductCommand = new DeleteProductCommand(id);

        var response = await Mediator.Send(deleteProductCommand);

        return await response.GetActionResultAsync();
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchProductAsync(SearchProductRequest request)
    {
        var searchProductQuery = Mapper.Map<SearchProductQuery>(request);

        var response = await Mediator.Send(searchProductQuery);

        return await response.GetActionResultAsync();
    }
}