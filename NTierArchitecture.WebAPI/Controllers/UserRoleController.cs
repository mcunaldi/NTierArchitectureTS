using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Feature.UserRoles.SetUserRole;
using NTierArchitecture.WebAPI.Abstractions;

namespace NTierArchitecture.WebAPI.Controllers;

public sealed class UserRoleController : APIController
{
    public UserRoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SetRole(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }


}
