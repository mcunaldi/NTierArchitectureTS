using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Feature.Auth.Login;
using NTierArchitecture.Business.Feature.Auth.Register;
using NTierArchitecture.WebAPI.Abstractions;

namespace NTierArchitecture.WebAPI.Controllers;

[AllowAnonymous]
public sealed class AuthController : APIController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request,cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {       

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
