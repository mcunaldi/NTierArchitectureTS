using AutoMapper;
using NTierArchitecture.Business.Feature.Categories.CreateCategory;
using NTierArchitecture.Business.Feature.Categories.UpdateCategory;
using NTierArchitecture.Business.Feature.Products.CreateProduct;
using NTierArchitecture.Business.Feature.Products.UpdateProduct;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
