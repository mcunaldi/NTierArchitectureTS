using MediatR;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Events.Users;
public sealed class UserDomainEvent : INotification
{
    public AppUser AppUser { get;}
    public UserDomainEvent(AppUser appUser)
    {
        AppUser = appUser;
    }

}

public sealed class SendRegisterEmail : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        //notification.AppUser.Id;
        //mail gönderme işlemi

        return Task.CompletedTask;
    }
}
