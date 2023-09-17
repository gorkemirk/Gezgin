using System.Text;
using Business.Utilities.Security.Auth.Jwt.Interface;

namespace Business.Utilities.Security.Auth.Jwt;

public class HashingHelper : IHashingHelper
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (computedHash.Length != passwordHash.Length)
            {
                return false;
            }

            for (var i = 0; i < computedHash.Length; ++i)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }

        return true;
    }
}