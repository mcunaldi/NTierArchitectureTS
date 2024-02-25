using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Products.RemoveProduct;

internal sealed class RemoveProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveProductCommand, Unit>
{
    public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.GetByIdAsync(p=> p.Id == request.Id);

        if (product is null)
        {
            throw new ArgumentException("Girdiğiniz ID'ye ait ürün bulunamadı!");
        }



        productRepository.Remove(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
