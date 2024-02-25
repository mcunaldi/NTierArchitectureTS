﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebAPI.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class APIController : ControllerBase
{
    public readonly IMediator _mediator;

    protected APIController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
