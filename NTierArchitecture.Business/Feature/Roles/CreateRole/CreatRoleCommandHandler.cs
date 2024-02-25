using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Roles.CreateRole;

internal sealed class CreatRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreatRoleCommand, Unit>
{
    public async Task<Unit> Handle(CreatRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleIsExists = await roleRepository.AnyAsync(p => p.Name == request.Name);
        if (checkRoleIsExists)
        {
            throw new ArgumentException("Bu rol daha önce oluşturulmuş!");
        }

        AppRole appRole = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await roleRepository.AddAsync(appRole, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
