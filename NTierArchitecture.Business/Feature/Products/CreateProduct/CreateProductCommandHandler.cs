using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Unit>
{
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isProductNameIsExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductNameIsExists)
        {
            throw new ArgumentException("Bu ürün adı daha önce kullanılmış!");
        }

        Product product = mapper.Map<Product>(request);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
