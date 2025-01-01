namespace UrWave.Application.Command.Product.DeleteProduct;

using MediatR;

public sealed class DeleteProductCommand : IRequest<BaseResponse<bool>>
{
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}