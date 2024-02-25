using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Entities.Events.Users;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Feature.Auth.Register;

internal sealed class RegisterCommandHandler(UserManager<AppUser> userManager, IMediator mediator) : IRequestHandler<RegisterCommand, Unit>
{
    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExist = await userManager.FindByNameAsync(request.UserName);

        if (checkUserNameExist != null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailExists = await userManager.FindByEmailAsync(request.Email);
        if (checkEmailExists != null)
        {
            throw new ArgumentException("Bu email daha önce kullanılmış!");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            UserName = request.UserName,
            Name = request.Name,
            Lastname = request.Lastname
        };

        await userManager.CreateAsync(appUser, request.Password);
        await mediator.Publish(new UserDomainEvent(appUser));

        return Unit.Value;
    }
}
