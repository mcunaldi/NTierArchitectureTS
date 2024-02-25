using FluentValidation;

namespace NTierArchitecture.Business.Feature.Roles.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreatRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı boş olamaz!"); 
        RuleFor(p=> p.Name).NotNull().WithMessage("Role adı boş olamaz!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Role adı 3 karakterden kısa olamaz!");
    }
}