using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Categories.GetCategory;

internal sealed class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, List<Category>>
{
    public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await categoryRepository.GetAll().OrderBy(p => p.Name).ToListAsync();
    }
}

