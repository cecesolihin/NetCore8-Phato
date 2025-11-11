using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ThePatho.Provider.UserContext
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor accessor;

        public CurrentUserService(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }

        public ClaimsPrincipal? GetPrincipal() => accessor.HttpContext?.User;

        public string? GetUserId()
        {
            var user = accessor.HttpContext?.User;
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? user?.FindFirst("sub")?.Value;
        }

        public string? GetUserName()
        {
            var user = accessor.HttpContext?.User;
            // common claims: Name, preferred_username, unique_name, email, username
            return user?.FindFirst(ClaimTypes.Name)?.Value
                ?? user?.FindFirst("preferred_username")?.Value
                ?? user?.FindFirst("unique_name")?.Value
                ?? user?.FindFirst("username")?.Value
                ?? user?.FindFirst("name")?.Value
                ?? user?.Identity?.Name
                ?? user?.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}