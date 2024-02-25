using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Categories.CreateCategory;
public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Ürün adı null olamaz!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır!");
    }
}
