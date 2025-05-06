using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Jwt;


namespace ThePatho.Features.Identity.Authentication.Commands
{
    public record LoginCommand(string Username, string Password)
    : IRequest<ApiResponse<JwtResult>>;
}
