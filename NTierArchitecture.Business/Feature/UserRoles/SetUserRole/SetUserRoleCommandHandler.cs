using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.UserRoles.SetUserRole;

internal sealed class SetUserRoleCommandHandler(
    IUserRoleRepository roleRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<SetUserRoleCommand, Unit>
{
    public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        var checkIsRoleSetExists =
            await roleRepository
            .AnyAsync(p => p.AppUserId == request.UserId && p.AppRoleId == request.RoleId, cancellationToken);

        if (checkIsRoleSetExists)
        {
            throw new ArgumentException("Kullanıcı bu role zaten sahip!");
        }

        UserRole userRole = new()
        {
            AppRoleId = request.RoleId,
            AppUserId = request.UserId
        };

        await roleRepository.AddAsync(userRole, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
