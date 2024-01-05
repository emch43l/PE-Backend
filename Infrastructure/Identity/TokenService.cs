using System.Security.Claims;
using System.Text;
using ApplicationCore.Service;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Infrastructure.JWT;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Infrastructure.Identity;

public class TokenService : ITokenService
{
    private readonly JwtSettings _settings;

    private readonly IIdentityService _identityService;

    public TokenService(JwtSettings settings, IIdentityService identityService)
    {
        _settings = settings;
        _identityService = identityService;
    }

    public async Task<string> CreateToken(IUser user)
    {
        return new JwtBuilder()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(Encoding.UTF8.GetBytes(_settings.Secret))
            .AddClaim(JwtRegisteredClaimNames.Name, user.UserName)
            .AddClaim(ClaimTypes.NameIdentifier, user.Id)
            .AddClaim(JwtRegisteredClaimNames.Email, user.Email)
            .AddClaim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddDays(365).ToUnixTimeSeconds())
            .AddClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid())
            .AddClaim(ClaimTypes.Role, await _identityService.GetUserRolesByEmailAsync(user.Email))
            .Audience(_settings.Audience)
            .Issuer(_settings.Issuer)
            .Encode();
    }
}