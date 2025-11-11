using System.Security.Claims;

namespace ThePatho.Provider.UserContext
{
    public interface ICurrentUserService
    {
        string? GetUserName();
        string? GetUserId();
        ClaimsPrincipal? GetPrincipal();
    }
}