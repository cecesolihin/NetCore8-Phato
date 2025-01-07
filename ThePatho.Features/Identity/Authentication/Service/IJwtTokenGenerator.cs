using ThePatho.Domain.Models.Identity;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
