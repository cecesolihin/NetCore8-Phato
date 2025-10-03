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


        //public async Task<string> RegisterAsync(RegisterCommand request)
        //{
        //    var user = new User
        //    {
        //        Username = request.Username,
        //        Email = request.Email,
        //        EmailConfirmed = false,
        //        PhoneNumber = request.PhoneNumber,
        //        PasswordHash = request.Password,
        //    };

        //    var result = await _userManager.CreateAsync(user, request.Password);
        //    if (!result.Succeeded)
        //    {
        //        throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }

        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    return token; // Send this via email
        //}

        //public async Task<string> LoginAsync(LoginCommand request)
        //{
        //    var user = await _userManager.FindByNameAsync(request.Username) ??
        //               await _userManager.FindByEmailAsync(request.Username);

        //    if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        //    {
        //        throw new UnauthorizedAccessException("Invalid credentials");
        //    }

        //    if (!user.EmailConfirmed)
        //    {
        //        throw new UnauthorizedAccessException("Email not confirmed");
        //    }

        //    var token = _jwtTokenGenerator.GenerateToken(user);
        //    return token;
        //}
        public async Task<ApiResponse<JwtResult>> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Users)
                .Select(
                    "user_id as UserId",
                    "username as Username",
                    "full_name as FullName",
                    "email as Email",
                    "email_confirmed as EmailConfirmed",
                    "password_hash as PasswordHash",
                    "phone_number as PhoneNumber",
                    "phone_number_confirmed as PhoneNumberConfirmed",
                    "is_active as IsActive",
                    "is_locked as IsLocked",
                    "inserted_by as InsertedBy",
                    "inserted_date as InsertedDate",
                    "modified_by as ModifiedBy",
                    "modified_date as ModifiedDate"
                )
                .When(
                    !string.IsNullOrWhiteSpace(request.Username),
                    q => q.WhereIn("username", request.Username)
                );
            var user = await db.FirstOrDefaultAsync<User>(query);

            if (user == null)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.NotFound,
                    "User not found."
                );
            }

            if (!user.IsActive)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.Forbidden,
                    "User account is not active."
                );
            }

            if (user.IsLocked)
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
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("fullName", user.FullName ?? ""),
                new Claim("isActive", user.IsActive.ToString()),
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
