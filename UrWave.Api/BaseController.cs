namespace UrWave.Api;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected IMediator Mediator { get; }

    protected IMapper Mapper { get; }
}