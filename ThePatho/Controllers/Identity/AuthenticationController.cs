using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.Identity.Authentication.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Controllers.Identity
{
    [ApiController]
    [Route(ApiRoutes.IdentityMenu.Authentication)]
    [ApiExplorerSettings(GroupName = "Identity")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }
        [HttpPost(ApiRoutes.Methods.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
       
        [HttpPost(ApiRoutes.Methods.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        
        [HttpPost(ApiRoutes.Methods.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Logout)]
        public IActionResult Logout()
        {
            // Untuk JWT stateless, logout dilakukan di client dengan menghapus token.
            // Endpoint ini hanya memberikan response sukses.
            return ApiResult(new ApiResponse(System.Net.HttpStatusCode.OK, "Logged off successfully."));
        }

        [HttpPost(ApiRoutes.Methods.ChangePassword)]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.ResetPassword)]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.UserInfo)]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult UserInfo()
        {
            var identity = User.Identity;
            if (identity == null || !identity.IsAuthenticated)
            {
                return ApiResult(new ApiResponse(System.Net.HttpStatusCode.Unauthorized, "Session expired."));
            }

            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            return ApiResult(new ApiResponse<System.Collections.Generic.Dictionary<string, string>>(System.Net.HttpStatusCode.OK, claims, "User info."));
        }
    }
   
}
