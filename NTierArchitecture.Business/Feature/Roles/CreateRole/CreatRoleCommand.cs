using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Roles.CreateRole;
public sealed record CreatRoleCommand(
    string Name): IRequest<Unit>;
