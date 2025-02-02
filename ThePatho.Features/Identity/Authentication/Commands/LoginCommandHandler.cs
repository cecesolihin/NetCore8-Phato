using Azure;
using MediatR;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, NewApiResponse<JwtResult>>
    {
        private readonly IAuthenticationService authenticationService;
        public LoginCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<NewApiResponse<JwtResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await authenticationService.LoginAsync(request);

            if (response.Code != (ushort)HttpStatusCode.OK)
            {
                return new NewApiResponse<JwtResult>(
                    HttpStatusCode.BadRequest,
                    "Invalid credentials",
                    "The username or password is incorrect or the account is locked.");
            }

            return new NewApiResponse<JwtResult>(
        HttpStatusCode.OK,
        new JwtResult
        {
            JwtToken = response.Data.JwtToken,
            RefreshToken = response.Data.RefreshToken
        });
        }
    }
}
