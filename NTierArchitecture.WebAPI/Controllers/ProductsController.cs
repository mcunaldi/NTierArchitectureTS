using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Feature.Products.CreateProduct;
using NTierArchitecture.Business.Feature.Products.GetProduct;
using NTierArchitecture.Business.Feature.Products.RemoveProduct;
using NTierArchitecture.Business.Feature.Products.UpdateProduct;
using NTierArchitecture.DataAccess.Auhorization;
using NTierArchitecture.WebAPI.Abstractions;

namespace NTierArchitecture.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController : APIController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("Product.Add")]
    public async Task<IActionResult> Add(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.Update")]
    public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.Remove")]
    public async Task<IActionResult> RemoveById(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.GetAll")]
    public async Task<IActionResult> GetAll(GetProductQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
