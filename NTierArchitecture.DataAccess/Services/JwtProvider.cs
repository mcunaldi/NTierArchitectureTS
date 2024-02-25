using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Abstractions;
using NTierArchitecture.Entities.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierArchitecture.Entities.Services;
internal sealed class JwtProvider(ApplicationDbContext context,
   IOptions<Jwt> jwt) : IJwtProvider
{
    public async Task<string> CreateTokenAsync(AppUser user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("NameLastname", string.Join(" ", user.Name, user.Lastname)),
            new Claim("Email", user.Email)
        };

        JwtSecurityToken securityToken = new(
            issuer: jwt.Value.Issuer,
            audience: jwt.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddSeconds(10),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(securityToken);

        return token;
    }
}
