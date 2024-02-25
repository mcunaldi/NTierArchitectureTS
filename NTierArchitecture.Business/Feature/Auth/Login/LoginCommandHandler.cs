using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Win32.SafeHandles;
using NTierArchitecture.Entities.Abstractions;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Feature.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> userManager,
    IJwtProvider jwtProivder) : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.Where(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }

        bool checkPassword = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (!checkPassword)
        {
            throw new ArgumentException("Şifre yanlış!");
        }

        string token = await jwtProivder.CreateTokenAsync(appUser);

        return new(AccessToken: token, UserId: appUser.Id);
    }
}
