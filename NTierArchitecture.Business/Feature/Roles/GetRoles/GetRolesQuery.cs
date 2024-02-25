using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Roles.GetRoles;
public sealed record GetRolesQuery() : IRequest<List<GetRolesQueryResponse>>;
