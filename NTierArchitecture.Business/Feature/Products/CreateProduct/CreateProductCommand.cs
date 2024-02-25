using MediatR;

namespace NTierArchitecture.Business.Feature.Products.CreateProduct;
public sealed record CreateProductCommand(
    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId) : IRequest<Unit>;
