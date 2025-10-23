using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using SqlKata;
using SqlKata.Execution;
using System.Data.Entity;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Identity;
using ThePatho.Features.Identity.Authentication.Commands;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using System.Net;
using ThePatho.Provider.Jwt;
using ThePatho.Provider.Jwt.Token;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http.Authentication;
using System.Threading;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        //private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly ITokenGenerator tokenGenerator;
        private readonly ApplicationDbContext dbContext;
        private readonly DapperContext dapperContext;
        private readonly IConfiguration configuration;

        public AuthenticationService
        (
            ApplicationDbContext _dbContext,
            IJwtTokenGenerator _jwtTokenGenerator, 
            DapperContext _dapperContext,
            IConfiguration _configuration,
            ITokenGenerator _tokenGenerator)
        {
            // _userManager = userManager;
            jwtTokenGenerator = _jwtTokenGenerator;
            dbContext = _dbContext;
            dapperContext = _dapperContext;
            tokenGenerator = _tokenGenerator;
            configuration = _configuration;
        }

        public async Task<ApiResponse<JwtResult>> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableIdentity.Users)
                .Select( "*")
                .When(
                    !string.IsNullOrWhiteSpace(request.Username),
                    q => q.WhereIn("UserName", request.Username)
                );
            var user = await db.FirstOrDefaultAsync<User>(query);

            if (user == null)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.NotFound,
                    "User not found."
                );
            }

            if (!user.Activated)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.Forbidden,
                    "User account is not active."
                );
            }

            if (user.LockoutEnabled)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.Forbidden,
                    "User account is locked."
                );
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.Unauthorized,
                    "Wrong password."
                );
            }

            //var jwtResult = jwtTokenGenerator.GenerateToken(user);

            var authenticationResult = await this.Authenticate(user, cancellationToken);

            return new ApiResponse<JwtResult>(
                HttpStatusCode.OK,
                authenticationResult
            );
        }

        public async Task<JwtResult> Authenticate(User user, CancellationToken token)
        {
            var refreshToken = tokenGenerator.GenerateRefreshToken();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("fullName", string.Format($"{user.FirstName} {user.LastName}")),
                new Claim("activated", user.Activated.ToString()),
            };
            var userJwt = tokenGenerator.GenerateToken(claims);

            return new JwtResult(userJwt, refreshToken);
        }
        public async Task<ApiResponse<JwtResult>> RegisterAsync(RegisterCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
