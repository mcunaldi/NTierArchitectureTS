using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler(IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.GetByIdAsync(p=> p.Id == request.Id);

        if (product is null)
        {
            throw new ArgumentException("Girdiğiniz ID'ye ait ürün bulunamadı!");
        }

        if(product.Name != request.Name)
        {
            var isProductNameExist = await productRepository.AnyAsync(p=> p.Name == request.Name, cancellationToken);

            if (isProductNameExist)
            {
                throw new ArgumentException("Girdiğiniz isme ait ürün bulunamadı!");
            }
        }

        mapper.Map(request, product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
