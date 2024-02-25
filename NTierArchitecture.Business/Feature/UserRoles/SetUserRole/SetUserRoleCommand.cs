using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Business.Feature.Roles.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.UserRoles.SetUserRole;
public sealed record SetUserRoleCommand(
    Guid UserId,
    Guid RoleId) : IRequest<Unit>;
