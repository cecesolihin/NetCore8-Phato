using Microsoft.AspNetCore.Identity;
using ThePatho.Domain.Models.Identity;
using ThePatho.Features.Identity.Authentication.Commands;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public Task<string> LoginAsync(LoginCommand request)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync(RegisterCommand request)
        {
            throw new NotImplementedException();
        }


        //public AuthenticationService(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
        //{
        //    _userManager = userManager;
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //}
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
    }
}
