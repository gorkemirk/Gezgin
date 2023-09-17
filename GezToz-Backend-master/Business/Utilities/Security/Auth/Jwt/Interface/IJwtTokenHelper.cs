using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Security.Auth.Jwt.Interface;

public interface IJwtTokenHelper
{
    Token CreateAccessToken(User user, string refreshToken);
}