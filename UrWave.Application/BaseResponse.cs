namespace UrWave.Application;

using Microsoft.AspNetCore.Mvc;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public List<string> Errors { get; set; } = new List<string>();
    public T Data { get; set; }

    public Task<IActionResult> GetActionResultAsync()
    {
        if (this.HasErrors())
        {
            return Task.FromResult<IActionResult>(new BadRequestObjectResult(this));
        }
        else
        {
            return Task.FromResult<IActionResult>(new OkObjectResult(this));
        }
    }

    public BaseResponse<T> BusinessValidationError(List<string> errors)
    {
        return new BaseResponse<T>
        {
            IsSuccess = false,
            Errors = errors,
            Data = default
        };
    }

    public BaseResponse<T> SuccessResponse(T data)
    {
        return new BaseResponse<T>
        {
            IsSuccess = true,
            Errors = new List<string>(),
            Data = data
        };
    }

    private bool HasErrors()
    {
        return !IsSuccess || Errors.Any();
    }
}