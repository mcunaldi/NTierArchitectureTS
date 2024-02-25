using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Feature.Categories.CreateCategory;
using NTierArchitecture.Business.Feature.Categories.DeleteCategory;
using NTierArchitecture.Business.Feature.Categories.GetCategory;
using NTierArchitecture.Business.Feature.Categories.UpdateCategory;
using NTierArchitecture.DataAccess.Auhorization;
using NTierArchitecture.WebAPI.Abstractions;

namespace NTierArchitecture.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class CategoriesController : APIController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("Category.Add")]
    public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.Update")]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.Remove")]
    public async Task<IActionResult> RemoveById(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.GetAll")]
    public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
