using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Auth.Login;
public sealed record class LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
