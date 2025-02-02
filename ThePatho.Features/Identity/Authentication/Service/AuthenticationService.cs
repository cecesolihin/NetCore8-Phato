using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using SqlKata;
using SqlKata.Execution;
using System.Data.Entity;
using ThePatho.Domain.Constants;
using ThePatho.Domain.Models.Identity;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.Authentication.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Infrastructure.Persistance;
using System.Net;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        //private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly ApplicationDbContext dbContext;
        private readonly DapperContext dapperContext;

        public AuthenticationService(ApplicationDbContext _dbContext,IJwtTokenGenerator _jwtTokenGenerator, DapperContext _dapperContext)
        {
            // _userManager = userManager;
            jwtTokenGenerator = _jwtTokenGenerator;
            dbContext = _dbContext;
            dapperContext = _dapperContext;
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
        public async Task<NewApiResponse<JwtResult>> LoginAsync(LoginCommand request)
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

            if (user == null || !user.IsActive || user.IsLocked)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // 🔹 Validasi password menggunakan BCrypt
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var jwtResult = jwtTokenGenerator.GenerateToken(user);

            return new NewApiResponse<JwtResult>(HttpStatusCode.OK, new JwtResult() { JwtToken = jwtResult, RefreshToken=jwtResult});
        }

        public async Task<NewApiResponse<JwtResult>> RegisterAsync(RegisterCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
