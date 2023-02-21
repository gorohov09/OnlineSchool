using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.App.Authentication.Commands.Register;
using OnlineSchool.App.Authentication.Common;
using OnlineSchool.Contracts.Authentication;

namespace OnlineSchool.API.Controllers;

[Route("api/auth")]
[AllowAnonymous]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password, request.IsStudent);

        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(Map(authResult)),
            errors => Problem("Ошибка")
            );
    }

    private AuthenticationResponse Map(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.Token);
    }
}
