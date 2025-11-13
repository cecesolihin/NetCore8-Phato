using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ThePatho.Domain.Models.Identity;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Email;
using ThePatho.Features.Identity.Authentication.DTO;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse<RegisterResponseDto>>
    {
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILogger<RegisterCommandHandler> _logger;
        private readonly IEmailService _emailService;

        public RegisterCommandHandler(
            IUserStore<User> userStore,
            IPasswordHasher<User> passwordHasher,
            ILogger<RegisterCommandHandler> logger,
            IEmailService emailService)
        {
            _userStore = userStore;
            _emailStore = (IUserEmailStore<User>)userStore;
            _passwordHasher = passwordHasher;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<ApiResponse<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if user already exists
                var existingUser = await _userStore.FindByNameAsync(request.Username!, cancellationToken);
                if (existingUser != null)
                {
                    return new ApiResponse<RegisterResponseDto>(HttpStatusCode.BadRequest, "User already exists");
                }

                var existingEmail = await _emailStore.FindByEmailAsync(request.Email!, cancellationToken);
                if (existingEmail != null)
                {
                    return new ApiResponse<RegisterResponseDto>(HttpStatusCode.BadRequest, "Email already registered");
                }

                // Split fullname into first and last name
                var names = request.Fullname?.Split(' ') ?? new[] { "User", "" };
                var firstName = names[0];
                var lastName = names.Length > 1 ? string.Join(" ", names.Skip(1)) : "";

                // Create new user
                var user = new User
                {
                    UserName = request.Username!,
                    Email = request.Email!,
                    FirstName = firstName,
                    LastName = lastName,
                    Activated = true,
                    InsertedDate = DateTime.UtcNow,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                };

                // Hash password
                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password!);

                // Create user
                var result = await _userStore.CreateAsync(user, cancellationToken);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new ApiResponse<RegisterResponseDto>(HttpStatusCode.BadRequest, $"Failed to create user: {errors}");
                }

                // Send welcome email
                try
                {
                    var emailSubject = "Welcome to ThePatho System";
                    var emailBody = $@"
                        <h2>Selamat Datang di ThePatho System!</h2>
                        <p>Halo <strong>{firstName} {lastName}</strong>,</p>
                        <p>Akun Anda telah berhasil dibuat dengan username: <strong>{request.Username}</strong></p>
                        <p>Anda sekarang dapat login ke sistem kami menggunakan email dan password yang telah Anda daftarkan.</p>
                        <p>Terima kasih telah bergabung!</p>
                        <br>
                        <p>Salam,<br>ThePatho Team</p>
                    ";

                    await _emailService.SendEmailAsync(request.Email!, emailSubject, emailBody, true);
                    _logger.LogInformation("Welcome email sent successfully to {Email}", request.Email!);
                }
                catch (Exception emailEx)
                {
                    _logger.LogWarning(emailEx, "Failed to send welcome email to {Email}", request.Email!);
                    // Don't fail the registration if email fails
                }

                var response = new RegisterResponseDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName ?? firstName,
                    LastName = user.LastName ?? lastName,
                    Message = "Registration successful. Welcome email will be sent shortly."
                };

                return new ApiResponse<RegisterResponseDto>(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                return new ApiResponse<RegisterResponseDto>(HttpStatusCode.InternalServerError, "An error occurred during registration");
            }
        }
    }
}