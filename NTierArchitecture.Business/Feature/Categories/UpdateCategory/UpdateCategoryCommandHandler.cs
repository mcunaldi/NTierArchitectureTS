using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByIdAsync(p=> p.Id == request.Id);

        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }

        if (category.Name != request.Name)
        {
            var isCategoryNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isCategoryNameExists)
            {
                throw new ArgumentException("Girdiğiniz kategori ismine ait değer bulunamadı!");
            }
        }

        mapper.Map(request, category);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
