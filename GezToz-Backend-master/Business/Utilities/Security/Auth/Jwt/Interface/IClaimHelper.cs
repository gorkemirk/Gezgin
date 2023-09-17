using System.Runtime.InteropServices.ComTypes;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Security.Auth.Jwt.Interface;

public interface IClaimHelper
{
    int? GetUserId();
    UserType? GetUserType();
    string? GetClaimByType(string claimType);
}