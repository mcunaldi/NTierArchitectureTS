using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Products.GetProduct;

internal sealed class GetProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync();
    }
}
