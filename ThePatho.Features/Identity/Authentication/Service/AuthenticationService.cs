using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using ThePatho.Domain.Models.Identity;
using ThePatho.Features.Identity.Authentication.Commands;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Jwt;
using ThePatho.Provider.Jwt.Token;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticationService
        (
            ApplicationDbContext dbContext,
            UserManager<User> userManager,
            ITokenGenerator tokenGenerator,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<ApiResponse<JwtResult>> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.Username);

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
                        "User Account is not active."
                    );
                }

                if (user.LockoutEnabled && user.LockoutEndDateUtc.HasValue && user.LockoutEndDateUtc > DateTime.UtcNow)
                {
                    return new ApiResponse<JwtResult>(
                        HttpStatusCode.Forbidden,
                        "User account locked."
                    );
                }
                
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    //return new ApiResponse<JwtResult>(
                    //    HttpStatusCode.Unauthorized,
                    //    "Wrong password."
                    //);
                    //Menambah jumlah percobaan login yang gagal
                    await _userManager.AccessFailedAsync(user);

                    return new ApiResponse<JwtResult>(
                        HttpStatusCode.Unauthorized,
                        "Wrong Password."
                    );
                }
                //// Verifikasi password menggunakan UserManager
                //var isPasswordValid = await CheckPasswordAsync(user, request.Password, cancellationToken);
                //if (!isPasswordValid)
                //{
                //    // Menambah jumlah percobaan login yang gagal
                //    await _userManager.AccessFailedAsync(user);

                //    return new ApiResponse<JwtResult>(
                //        HttpStatusCode.Unauthorized,
                //        "Password salah."
                //    );
                //}

                // Reset jumlah percobaan login yang gagal
                await _userManager.ResetAccessFailedCountAsync(user);

                // Update waktu login terakhir
                user.LastLoginTime = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                var authenticationResult = await this.Authenticate(user, cancellationToken);
                
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.OK,
                    authenticationResult
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.OK,
                    ex.Message.ToString()
                );
            }

        }

        public async Task<JwtResult> Authenticate(User user, CancellationToken token)
        {
            //Mendapatkan roles user(jika diperlukan)
            //var userRoles = await _userManager.GetRolesAsync(user);
            //Mendapatkan user group (jika diperlukan)
            var userGroups = await GetUserGroupAsync(user, token);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("fullName", string.Format($"{user.FirstName} {user.LastName}")),
                new Claim("activated", user.Activated.ToString()),
            };

            //foreach (var role in userRoles)
            //{
            //    claims.Add(new Claim("Permission", role));
            //}

            foreach (var gr in userGroups)
            {
                claims.Add(new Claim("Group", gr));
            }
            var refreshToken = _tokenGenerator.GenerateRefreshToken();
            var (accessToken, expiresAt) = _tokenGenerator.GenerateToken(claims);

            return new JwtResult(accessToken, refreshToken, expiresAt);
        }

        public async Task<ApiResponse<JwtResult>> RegisterAsync(RegisterCommand request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<JwtResult>> RefreshTokenAsync(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Validasi refresh token
            if (!_tokenGenerator.ValidateRefreshToken(request.RefreshToken))
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.Unauthorized,
                    "Refresh token tidak valid atau sudah kedaluwarsa."
                );
            }

            // Ekstrak user ID dari token lama
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            if (!tokenHandler.CanReadToken(request.Token))
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.BadRequest,
                    "Token tidak valid."
                );
            }

            var jwtToken = tokenHandler.ReadJwtToken(request.Token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);
            
            if (userIdClaim == null)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.BadRequest,
                    "Token tidak mengandung informasi pengguna yang valid."
                );
            }

            // Cari user berdasarkan ID
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
            {
                return new ApiResponse<JwtResult>(
                    HttpStatusCode.NotFound,
                    "Pengguna tidak ditemukan."
                );
            }

            // Generate token baru
            var authenticationResult = await Authenticate(user, cancellationToken);

            return new ApiResponse<JwtResult>(
                HttpStatusCode.OK,
                authenticationResult
            );
        }

        private async Task<bool> CheckPasswordAsync(User user, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                return false;

            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser == null || string.IsNullOrEmpty(existingUser.PasswordHash))
                return false;

            // Verifikasi password menggunakan BCrypt
            bool isValid = BCrypt.Net.BCrypt.Verify(password, existingUser.PasswordHash);

            return isValid;
        }
        public Task<IList<string>> GetUserGroupAsync(User user, CancellationToken cancellationToken)
        {
            var groups = (from ug in _dbContext.UserGroups
                         join g in _dbContext.Groups on ug.GroupId equals g.Id
                         where ug.UserId == user.Id
                         select g.Name).ToList();

            return Task.FromResult<IList<string>>(groups);
        }
    }
}
