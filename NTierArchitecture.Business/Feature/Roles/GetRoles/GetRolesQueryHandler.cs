using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Feature.Roles.GetRoles;

internal sealed class GetRolesQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetRolesQuery, List<GetRolesQueryResponse>>
{
    public async Task<List<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var response = 
            await roleRepository
            .GetAll()
            .Select(r => new GetRolesQueryResponse(r.Id, r.Name))
            .ToListAsync(cancellationToken);

        return response; 
    }
}
