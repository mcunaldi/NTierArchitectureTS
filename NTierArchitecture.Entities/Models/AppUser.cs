using Microsoft.AspNetCore.Identity;

namespace NTierArchitecture.Entities.Models;
public sealed class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}
