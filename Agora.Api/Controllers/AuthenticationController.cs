using Agora.Application.Authentication.Login;
using Agora.Application.Authentication.RegisterUser;
using Agora.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agora.Api.Controllers;

[Route("")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> UserRegister(RegisterUserRequest request)
    {
        var command = _mapper.Map<RegisterUserCommand>(request);
        ErrorOr<RegisterUserResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<LoginResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}
