using System.Security.Claims;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Utilities.Security.Auth.Jwt;

public class ClaimHelper : IClaimHelper
{
    private readonly IEnumerable<Claim> _claims;

    public ClaimHelper(IHttpContextAccessor httpContextAccessor)
    {
        _claims = httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();
    }

    public int? GetUserId()
    {
        if (int.TryParse(_claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var id))
        {
            return id;
        }

        return null;
    }

    public UserType? GetUserType()
    {
        if (Enum.TryParse<UserType>(_claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)?.Value, out var userType))
        {
            return userType;
        }

        return null;
    }

    public string? GetClaimByType(string claimType)
    {
        return _claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    }
}