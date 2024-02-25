using MediatR;

namespace NTierArchitecture.Business.Feature.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(
    Guid Id,
    string Name): IRequest;
