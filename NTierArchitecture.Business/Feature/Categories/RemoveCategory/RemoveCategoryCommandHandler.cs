using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Categories.DeleteCategory;

internal sealed class RemoveCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommand>
{
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByIdAsync(p => p.Id == request.Id);

        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        };

        categoryRepository.Remove(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
