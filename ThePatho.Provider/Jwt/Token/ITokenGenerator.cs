using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Provider.Jwt.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(IEnumerable<Claim>? claims = default);
        string GenerateRefreshToken();
        bool ValidateRefreshToken(string? refreshToken);
    }
}
